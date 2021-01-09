using System;
using System.Collections.Generic;
using NLog;
using Poseidon.BusinessLayer.Servers;
using Poseidon.DataLayer.Cloud;
using Poseidon.DataLayer.HealthChecks;
using Poseidon.DataLayer.Servers;
using Poseidon.Models.HealthChecks;

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
        public HealthCheckManager(IHealthCheckDal healthCheckDal, IServerDal serverDal, ICloudProviderDal cloudProviderDal)
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
        public ICollection<HealthCheck> GetHealthChecks(bool includeServers=true)
        {
            try
            {
                var healthChecks = _healthCheckDal.GetHealthChecks();
                if(includeServers)
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

        #endregion
    }
}