using Microsoft.AspNetCore.Mvc;
using Poseidon.BusinessLayer.Cloud;
using Poseidon.DataLayer.Servers;

namespace Poseidon.Api.Controllers
{
    [Route("digitalocean")]
    [ApiController]
    public class DigitalOceanController : CloudControllerBase
    {
        #region Constructors

        public DigitalOceanController(IServerDal serverDal) : base(serverDal, CloudManagerHelper.GetDigitalOceanDal())
        {
        }

        #endregion
    }
}