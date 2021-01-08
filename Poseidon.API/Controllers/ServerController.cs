using System;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Poseidon.BusinessLayer.Servers;
using Poseidon.DataLayer.Servers;

namespace Poseidon.Api.Controllers
{
    [Route("/poseidon/servers")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        #region Fields

        protected readonly ServerManager ServerManager;

        #endregion

        #region Properties

        public ILogger Logger { get; } = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors

        public ServerController(IServerDal serverDal)
        {
            ServerManager = new ServerManager(serverDal);
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

            return BadRequest(new {Message = "Failed to delete server"});
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

            return BadRequest(new {Message = "Failed to get server"});
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
                return BadRequest(new {e.Message});
            }
        }

        #endregion
    }
}