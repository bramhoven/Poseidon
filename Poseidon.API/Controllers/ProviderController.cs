using System;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Poseidon.BusinessLayer.Cloud;
using Poseidon.DataLayer.Cloud;

namespace Poseidon.Api.Controllers
{
    [Route("poseidon/providers")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        #region Fields

        private readonly CloudProviderManager _cloudProviderManager;

        #endregion

        #region Properties

        public ILogger Logger { get; } = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors

        public ProviderController(ICloudProviderDal cloudProviderDal)
        {
            _cloudProviderManager = new CloudProviderManager(cloudProviderDal);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Get all providers.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<object> GetServers()
        {
            try
            {
                return Ok(_cloudProviderManager.GetCloudProviders());
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