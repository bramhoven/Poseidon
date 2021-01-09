using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using NLog;
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