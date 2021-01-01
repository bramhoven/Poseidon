using System;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Poseidon.BusinessLayer.Servers;
using Poseidon.DataLayer.Servers;

namespace Poseidon.Api.Controllers
{
    [Route("/servers")]
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