using NLog;
using Sertar.DataLayer.Servers;
using Sertar.Models.Servers;

namespace Sertar.BusinessLayer.Servers
{
    public class ServerManager
    {
        #region Fields

        /// <summary>
        ///     The logger.
        /// </summary>
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     The server dal.
        /// </summary>
        private readonly IServerDal _serverDal;

        #endregion

        #region Constructors

        /// <summary>
        ///     Instantiates a new instance of <see cref="Sertar.BusinessLayer.Servers.ServerManager" />
        /// </summary>
        /// <param name="serverDal"></param>
        public ServerManager(IServerDal serverDal)
        {
            _serverDal = serverDal;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Deletes the server.
        /// </summary>
        /// <param name="server">The server</param>
        /// <returns></returns>
        public bool DeleteServer(Server server)
        {
            return _serverDal.DeleteServer(server);
        }

        /// <summary>
        ///     Insert the server.
        /// </summary>
        /// <param name="server">The server</param>
        /// <returns></returns>
        public bool InsertServer(Server server)
        {
            return _serverDal.InsertServer(server);
        }

        /// <summary>
        ///     Updates the server.
        /// </summary>
        /// <param name="server">The server</param>
        public bool UpdateServer(Server server)
        {
            return _serverDal.UpdateServer(server);
        }

        #endregion
    }
}