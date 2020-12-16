using NLog;
using Poseidon.DataLayer.Servers;
using Poseidon.Models.Servers;
using System;

namespace Poseidon.BusinessLayer.Servers
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
        ///     Instantiates a new instance of <see cref="ServerManager" />
        /// </summary>
        /// <param name="serverDal"></param>
        public ServerManager(IServerDal serverDal)
        {
            _serverDal = serverDal;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get server by GUID.
        /// </summary>
        /// <param name="id">The id of the server</param>
        /// <returns></returns>
        public Server GetServer(Guid id)
        {
            return _serverDal.GetServer(id);
        }

        /// <summary>
        /// Get server by id as string.
        /// </summary>
        /// <param name="id">The id of the server as string</param>
        /// <returns></returns>
        public Server GetServer(string id)
        {
            return _serverDal.GetServer(Guid.Parse(id));
        }

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