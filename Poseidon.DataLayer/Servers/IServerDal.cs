using System;
using System.Collections.Generic;
using Poseidon.DataLayer.Contexts.ServerContext;
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
        ///     Gets a server.
        /// </summary>
        /// <param name="id">The id of the server</param>
        /// <returns></returns>
        Server GetServer(Guid id);

        /// <summary>
        ///     Gets a server by cloud id.
        /// </summary>
        /// <param name="cloudId">The cloud id of the server</param>
        /// <returns></returns>
        Server GetServerByCloudId(string cloudId);

        /// <summary>
        ///     Gets the server context.
        /// </summary>
        /// <returns></returns>
        DbServerContext GetServerContext();

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