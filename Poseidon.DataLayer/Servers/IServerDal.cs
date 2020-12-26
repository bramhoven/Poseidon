using System;
using System.Collections.Generic;
using Poseidon.Models.Servers;

namespace Poseidon.DataLayer.Servers
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
        /// Gets a server.
        /// </summary>
        /// <param name="id">The id of the server</param>
        /// <returns></returns>
        Server GetServer(Guid id);

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