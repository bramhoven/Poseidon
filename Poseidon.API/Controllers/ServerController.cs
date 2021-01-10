using System;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Poseidon.Api.Models;
using Poseidon.BusinessLayer.HealthChecks;
using Poseidon.BusinessLayer.Servers;
using Poseidon.DataLayer.Cloud;
using Poseidon.DataLayer.HealthChecks;
using Poseidon.DataLayer.Servers;

namespace Poseidon.Api.Controllers
{
    [Route("/poseidon/servers")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        #region Fields

        protected readonly HealthCheckManager HealthCheckManager;

        protected readonly ServerManager ServerManager;

        #endregion

        #region Properties

        public ILogger Logger { get; } = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of <see cref="ServerController" />
        /// </summary>
        /// <param name="serverDal">The server dal</param>
        /// <param name="cloudProviderDal">The cloud provider dal</param>
        /// <param name="healthCheckDal">The health check dal</param>
        public ServerController(IServerDal serverDal, ICloudProviderDal cloudProviderDal,
            IHealthCheckDal healthCheckDal)
        {
            ServerManager = new ServerManager(serverDal, cloudProviderDal);
            HealthCheckManager = new HealthCheckManager(healthCheckDal, serverDal, cloudProviderDal);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Deletes a server.
        /// </summary>
        /// <param name="serverId">The server id</param>
        /// <returns></returns>
        [Route("{serverId}")]
        [HttpDelete]
        public ActionResult<object> DeleteServer(string serverId)
        {
            try
            {
                if (ServerManager.DeleteServer(serverId))
                    return Ok();
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }

            return BadRequest(new ErrorMessage("Failed to delete server"));
        }

        /// <summary>
        ///     Gets a server.
        /// </summary>
        /// <param name="serverId">The server id</param>
        /// <returns></returns>
        [Route("{serverId}")]
        [HttpGet]
        public ActionResult<object> GetServer(string serverId)
        {
            try
            {
                var server = ServerManager.GetServer(serverId);
                if (server != null)
                    return Ok(server);
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }

            return BadRequest(new ErrorMessage("Failed to get server"));
        }

        /// <summary>
        ///     Get all health checks for a server.
        /// </summary>
        /// <returns></returns>
        [Route("{serverId}/healthchecks")]
        [HttpGet]
        public ActionResult<object> GetServerHealtChecks(string serverId)
        {
            try
            {
                var server = ServerManager.GetServer(serverId);
                if (server != null)
                {
                    var healthChecks = HealthCheckManager.GetHealthChecks(server, false);
                    return Ok(healthChecks);
                }

                return BadRequest(new ErrorMessage("Cannot get server for specified id"));
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }

            return BadRequest(new ErrorMessage("Cannot get health checks for server"));
        }

        /// <summary>
        ///     Get all servers.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<object> GetServers()
        {
            try
            {
                return Ok(ServerManager.GetServers());
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return BadRequest(new ErrorMessage(e.Message));
            }
        }

        #endregion
    }
}