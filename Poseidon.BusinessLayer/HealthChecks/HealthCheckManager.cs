using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Flurl;
using Flurl.Http;
using NLog;
using Poseidon.BusinessLayer.QueryLanguage;
using Poseidon.BusinessLayer.Servers;
using Poseidon.DataLayer.Cloud;
using Poseidon.DataLayer.HealthChecks;
using Poseidon.DataLayer.Servers;
using Poseidon.Models.Enums;
using Poseidon.Models.HealthChecks;
using Poseidon.Models.QueryLanguage.DataRepresentation;
using Poseidon.Models.Servers;

namespace Poseidon.BusinessLayer.HealthChecks
{
    public class HealthCheckManager
    {
        #region Fields

        private readonly IHealthCheckDal _healthCheckDal;
        private readonly QueryLanguageManager _queryLanguageManager;
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
            _queryLanguageManager = new QueryLanguageManager();
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
        ///     Get health checks for server.
        /// </summary>
        /// <param name="server">The server to get the checks for</param>
        /// <param name="includeServers">Whether to include the server object in the response</param>
        /// <returns></returns>
        public ICollection<HealthCheck> GetHealthChecks(Server server, bool includeServers = true)
        {
            try
            {
                var healthChecks = _healthCheckDal.GetHealthChecks(server.Id.ToString());
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
        ///     Query the health checks
        /// </summary>
        /// <param name="query">The query</param>
        /// <param name="includeServers">Whether to include the server object in the response</param>
        /// <returns></returns>
        public ICollection<HealthCheck> QueryHealthChecks(string query, bool includeServers = true)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException(nameof(query));

            try
            {
                var queryModel = _queryLanguageManager.ParseQuery(query);
                IEnumerable<HealthCheck> healthChecks = _healthCheckDal.GetHealthChecks();

                foreach (var comparisonCondition in queryModel.ComparisonConditions)
                { 
                    switch (comparisonCondition.Operator)
                    {
                        case DslOperator.NotEquals:
                            healthChecks = healthChecks.Where(h =>
                                !float.Parse(comparisonCondition.Value).Equals(h.DataItems.FirstOrDefault(d => d.Name.Equals(comparisonCondition.DataItemName))?.Data));
                            break;
                        case DslOperator.Equals:
                            healthChecks = healthChecks.Where(h =>
                                float.Parse(comparisonCondition.Value).Equals(h.DataItems.FirstOrDefault(d => d.Name.Equals(comparisonCondition.DataItemName))?.Data));
                            break;
                        case DslOperator.GreaterThan: 
                            healthChecks = healthChecks.Where(h =>
                                float.Parse(comparisonCondition.Value) < h.DataItems.FirstOrDefault(d => d.Name.Equals(comparisonCondition.DataItemName))?.Data);
                            break;
                        case DslOperator.GreaterEquals:
                            healthChecks = healthChecks.Where(h =>
                                float.Parse(comparisonCondition.Value) <= h.DataItems.FirstOrDefault(d => d.Name.Equals(comparisonCondition.DataItemName))?.Data);
                            break;
                        case DslOperator.LessThan:
                            healthChecks = healthChecks.Where(h =>
                                float.Parse(comparisonCondition.Value) > h.DataItems.FirstOrDefault(d => d.Name.Equals(comparisonCondition.DataItemName))?.Data);
                            break;
                        case DslOperator.LessEquals:
                            healthChecks = healthChecks.Where(h =>
                                float.Parse(comparisonCondition.Value) >= h.DataItems.FirstOrDefault(d => d.Name.Equals(comparisonCondition.DataItemName))?.Data);
                            break;
                    }
                }

                if (includeServers)
                    foreach (var healthCheck in healthChecks)
                        healthCheck.Server = _serverManager.GetServer(healthCheck.ServerId);

                return healthChecks.ToList();
            }
            catch (Exception e)
            {
                Logger.Error(e);
                throw e;
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
                    var protocol = "http";
                    if (healthCheckProperties.Protocol == ProtocolType.Https)
                        protocol = "https";

                    var baseUrl = $"{protocol}://{server.MainIpAddress}";

                    try
                    {
                        healthCheckDataItems = ExecuteHealthCheck(baseUrl, healthCheckProperties, ref stopwatch);
                    }
                    catch (FlurlHttpTimeoutException)
                    {
                        server.Status = ServerStatus.Offline;
                    }
                    catch (FlurlHttpException)
                    {
                        server.Status = ServerStatus.Failing;
                    }
                }

                if ((int) stopwatch.ElapsedMilliseconds <= 500)
                    server.Status = ServerStatus.Running;
                if ((int) stopwatch.ElapsedMilliseconds > 500)
                    server.Status = ServerStatus.Slow;

                _serverManager.UpdateServer(server);

                if (healthCheckDataItems != null)
                {
                    var healthCheck = new HealthCheck
                    {
                        Date = DateTime.Now,
                        DataItems = healthCheckDataItems,
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

        /// <summary>
        ///     Runs a health checks for all servers.
        /// </summary>
        /// <returns></returns>
        public bool RunHealthChecks()
        {
            var servers = _serverManager.GetServers();

            var result = true;
            foreach (var server in servers)
                result = RunHealthCheck(server) && result;

            return result;
        }

        #region Static Methods

        /// <summary>
        ///     Executes and times the health check
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="healthCheckProperties"></param>
        /// <param name="stopwatch"></param>
        /// <returns></returns>
        private static ICollection<HealthCheckDataItem> ExecuteHealthCheck(string baseUrl,
            HealthCheckProperties healthCheckProperties, ref Stopwatch stopwatch)
        {
            HealthCheckDataItem[] dataItems;

            try
            {
                stopwatch.Start();
                dataItems = baseUrl.AppendPathSegment(healthCheckProperties.HealthCheckPath)
                    .GetJsonAsync<HealthCheckDataItem[]>().Result;
            }
            catch (FlurlHttpException e)
            {
                throw e;
            }
            finally
            {
                stopwatch.Stop();
            }

            return dataItems.ToList();
        }

        #endregion

        #endregion
    }
}