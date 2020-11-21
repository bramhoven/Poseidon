using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Sertar.API.Models.RequestData;
using Sertar.BusinessLayer.Cloud;
using Sertar.BusinessLayer.Servers;
using Sertar.DataLayer.Cloud;
using Sertar.DataLayer.Contexts.ServerContext;
using Sertar.DataLayer.Servers;
using Sertar.Models.Cloud;

namespace Sertar.Api.Controllers
{
    [Route("api/ovh")]
    [ApiController]
    public class OvhController : ControllerBase
    {
        #region Fields

        private readonly CloudManager _cloudManager;
        private readonly ServerManager _serverManager;

        #endregion

        #region Constructors

        public OvhController(IServerDal serverDal)
        {
            _cloudManager = new CloudManager(new OvhCloudDal());
            _serverManager = new ServerManager(serverDal);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Create an server in the ovh cloud.
        /// </summary>
        /// <param name="serverCreateData">The server data</param>
        /// <returns></returns>
        [Route("servers")]
        [HttpPost]
        public ActionResult<object> CreateServer(ServerCreateData serverCreateData)
        {
            var server = _cloudManager.CreateServer(serverCreateData.Name, serverCreateData.Size,
                serverCreateData.Image,
                serverCreateData.Region);
            if (server != null)
            {
                _serverManager.InsertServer(server);
                return Ok(server);
            }

            return BadRequest(new {Message = "Failed to create server"});
        }

        /// <summary>
        ///     Gets an server in the ovh cloud.
        /// </summary>
        /// <param name="serverId">The server id</param>
        /// <returns></returns>
        [Route("servers/{serverId}")]
        [HttpGet]
        public ActionResult<object> GetServer(string serverId)
        {
            var server = _cloudManager.GetServer(serverId);
            if (server != null)
                return Ok(server);

            return BadRequest(new { Message = "Failed to get server" });
        }

        /// <summary>
        ///     Getting ovh's available sizes.
        /// </summary>
        /// <returns></returns>
        [Route("sizes")]
        [HttpGet]
        public ActionResult<ICollection<InstanceSizeBase>> GetAvailableSizes()
        {
            return Ok(_cloudManager.GetAvailableSizes());
        }

        /// <summary>
        ///     Getting ovh's available sizes by region.
        /// </summary>
        /// <param name="region">The region to filter by</param>
        /// <returns></returns>
        [Route("sizes/regions/{region}")]
        [HttpGet]
        public ActionResult<ICollection<InstanceSizeBase>> GetAvailableSizesForRegion(string region)
        {
            return Ok(_cloudManager.GetAvailableSizes(region));
        }

        /// <summary>
        ///     Getting ovh's available images.
        /// </summary>
        /// <returns></returns>
        [Route("images")]
        [HttpGet]
        public ActionResult<ICollection<InstanceSizeBase>> GetAvailableImages()
        {
            return Ok(_cloudManager.GetAvailableImages());
        }

        /// <summary>
        ///     Getting ovh's available images by region.
        /// </summary>
        /// <param name="region">The region to filter by</param>
        /// <returns></returns>
        [Route("images/regions/{region}")]
        [HttpGet]
        public ActionResult<ICollection<InstanceSizeBase>> GetAvailableImages(string region)
        {
            return Ok(_cloudManager.GetAvailableImages(region));
        }

        #endregion
    }
}