using Microsoft.AspNetCore.Mvc;
using Poseidon.BusinessLayer.Cloud;
using Poseidon.DataLayer.Cloud;
using Poseidon.DataLayer.Servers;

namespace Poseidon.Api.Controllers
{
    [Route("digitalocean")]
    [ApiController]
    public class DigitalOceanController : CloudControllerBase
    {
        #region Constructors

        public DigitalOceanController(IServerDal serverDal, ICloudProviderDal cloudProviderDal) : base(serverDal, CloudManagerHelper.GetDigitalOceanDal(), cloudProviderDal)
        {
        }

        #endregion
    }
}