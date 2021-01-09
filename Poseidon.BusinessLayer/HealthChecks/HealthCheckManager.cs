using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Flurl;
using Flurl.Http;
using NLog;
using Poseidon.BusinessLayer.Servers;
using Poseidon.DataLayer.Cloud;
using Poseidon.DataLayer.HealthChecks;
using Poseidon.DataLayer.Servers;
using Poseidon.Models.Enums;
using Poseidon.Models.HealthChecks;
using Poseidon.Models.Servers;

namespace Poseidon.BusinessLayer.HealthChecks
{
    public class HealthCheckManager
    {
        #region Fields

        private readonly IHealthCheckDal _healthCheckDal;
        private readonly ServerManager _serverManager;

        #endregion

        #region Properties

        private ILogger Logger => LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of <see cref="HealthCheckManager" />
        /// </summary>
        /// <param name="healthCheckDal">The health check dal</param>
        /// <param name="serverDal">The server dall</param>
        /// <param name="cloudProviderDal"></param>
        public HealthCheckManager(IHealthCheckDal healthCheckDal, IServerDal serverDal,
            ICloudProviderDal cloudProviderDal)
        {
            _healthCheckDal = healthCheckDal;
            _serverManager = new ServerManager(serverDal, cloudProviderDal);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Get all health checks.
        /// </summary>
        /// <param name="includeServers">Whether to include the server object in the response</param>
        /// <returns></returns>
        public ICollection<HealthCheck> GetHealthChecks(bool includeServers = true)
        {
            try
            {
                var healthChecks = _healthCheckDal.GetHealthChecks();
                if (includeServers)
                    foreach (var healthCheck in healthChecks)
                        healthCheck.Server = _serverManager.GetServer(healthCheck.ServerId);

                return healthChecks;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return new List<HealthCheck>();
            }
        }

        /// <summary>
        ///     Runs a health check for the specified server.
        /// </summary>
        /// <param name="server"></param>
        /// <returns></returns>
        public bool RunHealthCheck(Server server)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();

                var healthCheckProperties = server.HealthCheckProperties;

                ICollection<HealthCheckDataItem> healthCheckDataItems = null;
                if (healthCheckProperties.Protocol == ProtocolType.Http ||
                    healthCheckProperties.Protocol == ProtocolType.Https)
                {
                    stopwatch.Start();
                    var dataItems = server.MainIpAddress.AppendPathSegment(healthCheckProperties.HealthCheckPath)
                        .GetJsonAsync<HealthCheckDataItem[]>().Result;
                    stopwatch.Stop();

                    healthCheckDataItems = dataItems.ToList();
                }

                if (healthCheckDataItems != null)
                {
                    var healthCheck = new HealthCheck()
                    {
                        HealthCheckDataItems = healthCheckDataItems,
                        ResponseTime = (int) stopwatch.ElapsedMilliseconds,
                        Server = server
                    };
                    return _healthCheckDal.AddHealthCheck(healthCheck);
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }

            return false;
        }

        #endregion
    }
}