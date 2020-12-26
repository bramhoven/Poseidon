using Microsoft.AspNetCore.Mvc;
using NLog;
using Poseidon.API.Models.Statistics;
using Poseidon.BusinessLayer.Cloud;
using Poseidon.BusinessLayer.Servers;
using Poseidon.BusinessLayer.Users;
using Poseidon.DataLayer.Cloud;
using Poseidon.DataLayer.Servers;
using Poseidon.DataLayer.Users;

namespace Poseidon.Api.Controllers
{
    [Route("statistics")]
    [ApiController]
    public class StatisticsController : Controller
    {
        #region Fields

        private readonly UserManager _userManager;
        private readonly ServerManager _serverManager;

        #endregion

        #region Properties

        public ILogger Logger { get; } = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors

        public StatisticsController(IServerDal serverDal, IUserDal userDal)
        {
            _serverManager = new ServerManager(serverDal);
            _userManager = new UserManager(userDal, null);
        }

        #endregion

        #region Methods


        [HttpGet]
        public IActionResult GetStatistics()
        {
            var serverCount = _serverManager.GetServers().Count;
            var userCount = _userManager.GetUsers().Count;

            var model = new StatisticsModel()
            {
                ServerCount = serverCount,
                UserCount = 0
            };
            return Ok(model);
        }

        #endregion
    }
}