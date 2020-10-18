using System.Collections.Generic;
using Sertar.Models.Servers;

namespace Sertar.DataLayer.Servers
{
    public interface IServerDal
    {
        #region Methods

        /// <summary>
        ///     Delete server.
        /// </summary>
        /// <param name="server">The server to delete</param>
        /// <returns></returns>
        bool DeleteServer(Server server);

        /// <summary>
        ///     Get servers.
        /// </summary>
        /// <returns></returns>
        ICollection<Server> GetServers();

        /// <summary>
        ///     Insert server.
        /// </summary>
        /// <param name="server">The server to insert</param>
        /// <returns></returns>
        bool InsertServer(Server server);

        /// <summary>
        ///     Update server.
        /// </summary>
        /// <param name="server">The server to update</param>
        /// <returns></returns>
        bool UpdateServer(Server server);

        #endregion
    }
}