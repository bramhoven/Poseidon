using Microsoft.AspNetCore.Mvc;
using Poseidon.BusinessLayer.HealthChecks;
using Poseidon.DataLayer.Cloud;
using Poseidon.DataLayer.HealthChecks;
using Poseidon.DataLayer.Servers;

namespace Poseidon.Api.Controllers
{
    [Route("healthchecks")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        #region Fields

        private readonly HealthCheckManager _healthCheckManager;

        #endregion

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
        }

        #endregion

        #region Methods

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