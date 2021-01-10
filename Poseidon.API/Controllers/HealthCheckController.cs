using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Poseidon.Api.Models;
using Poseidon.BusinessLayer.HealthChecks;
using Poseidon.BusinessLayer.Servers;
using Poseidon.DataLayer.Cloud;
using Poseidon.DataLayer.HealthChecks;
using Poseidon.DataLayer.Servers;
using Poseidon.Models.HealthChecks;

namespace Poseidon.Api.Controllers
{
    [Route("healthchecks")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        #region Fields

        private readonly HealthCheckManager _healthCheckManager;
        private readonly ServerManager _serverManager;

        #endregion

        private ILogger Logger => LogManager.GetCurrentClassLogger();

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of <see cref="HealthCheckController" />
        /// </summary>
        /// <param name="healthCheckDal">The health check dal</param>
        /// <param name="serverDal">The server dal</param>
        /// <param name="cloudProviderDal">The cloud provider dal</param>
        public HealthCheckController(IHealthCheckDal healthCheckDal, IServerDal serverDal,
            ICloudProviderDal cloudProviderDal)
        {
            _healthCheckManager = new HealthCheckManager(healthCheckDal, serverDal, cloudProviderDal);
            _serverManager = new ServerManager(serverDal, cloudProviderDal);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Runs a health check.
        /// </summary>
        /// <param name="serverId">The server id</param>
        /// <returns></returns>
        [Route("{serverId}")]
        [HttpPost]
        public ActionResult<object> RunHealthCheck(string serverId)
        {
            try
            {
                var server = _serverManager.GetServer(serverId);
                if (server != null)
                    if(_healthCheckManager.RunHealthCheck(server))
                        return Ok();
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }

            return BadRequest(new {Message = "Failed to run health check"});
        }

        /// <summary>
        ///     Query the health checks.
        /// </summary>
        /// <param name="query">The query</param>
        /// <returns></returns>
        [Route("query")]
        [HttpGet]
        public ActionResult<object> QueryHealthChecks(string query, bool includeServers = true)
        {
            try
            {
                var healthChecks = _healthCheckManager.QueryHealthChecks(query, includeServers);

                return Ok(healthChecks);
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorMessage(e.Message));
            }
        }

        /// <summary>
        ///     Gets all the health checks.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<object> GetAllHealthChecks(bool includeServers=true)
        {
            var healthChecks = _healthCheckManager.GetHealthChecks(includeServers);

            return Ok(healthChecks);
        }

        #endregion
    }
}