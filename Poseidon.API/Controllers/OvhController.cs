using Microsoft.AspNetCore.Mvc;
using Poseidon.BusinessLayer.Cloud;
using Poseidon.DataLayer.Cloud;
using Poseidon.DataLayer.Servers;

namespace Poseidon.Api.Controllers
{
    [Route("ovh")]
    [ApiController]
    public class OvhController : CloudControllerBase
    {
        #region Constructors

        public OvhController(IServerDal serverDal, ICloudProviderDal cloudProviderDal) : base(serverDal, CloudManagerHelper.GetOvhDal(), cloudProviderDal)
        {
        }

        #endregion
    }
}