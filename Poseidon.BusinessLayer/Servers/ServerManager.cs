using System;
using System.Collections.Generic;
using NLog;
using Poseidon.BusinessLayer.Cloud;
using Poseidon.DataLayer.Cloud;
using Poseidon.DataLayer.Servers;
using Poseidon.Models.Servers;

namespace Poseidon.BusinessLayer.Servers
{
    public class ServerManager
    {
        #region Fields

        /// <summary>
        ///     The cloud provider manager.
        /// </summary>
        private readonly CloudProviderManager _cloudProviderManager;

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
        /// <param name="serverDal">The server provider dal</param>
        /// <param name="cloudProviderDal">The cloud provider dal</param>
        public ServerManager(IServerDal serverDal, ICloudProviderDal cloudProviderDal)
        {
            _serverDal = serverDal;
            _cloudProviderManager = new CloudProviderManager(cloudProviderDal);
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
            return DeleteServer(server.Id.ToString());
        }

        /// <summary>
        ///     Deletes the server.
        /// </summary>
        /// <param name="serverId">The server id</param>
        /// <returns></returns>
        public bool DeleteServer(string serverId)
        {
            var server = GetServer(serverId);
            if (server == null)
                throw new Exception($"Cannot find server for id {serverId}");

            var cloudDal = CloudManagerHelper.GetDalForServer(server);
            if (cloudDal == null)
                throw new Exception("Cannot find cloud dal for server");

            var cloudManager = new CloudManager(cloudDal);
            var cloudServer = cloudManager.GetServer(server.CloudId);
            return cloudServer != null
                ? cloudManager.DeleteServer(server.CloudId)
                : true && _serverDal.DeleteServer(server);
        }

        /// <summary>
        ///     Get server by GUID.
        /// </summary>
        /// <param name="id">The id of the server</param>
        /// <returns></returns>
        public Server GetServer(Guid id)
        {
            return _serverDal.GetServer(id);
        }

        /// <summary>
        ///     Get server by id as string.
        /// </summary>
        /// <param name="id">The id of the server as string</param>
        /// <returns></returns>
        public Server GetServer(string id)
        {
            var server = _serverDal.GetServer(Guid.Parse(id));
            if(server.CloudProviderId != null && server.CloudProviderId > 0)
                server.CloudProvider = _cloudProviderManager.GetCloudProvider(server.CloudProviderId ?? 0);
            return server;
        }

        /// <summary>
        ///     Get server by cloud id.
        /// </summary>
        /// <param name="id">The id of the server</param>
        /// <returns></returns>
        public Server GetServerByCloudId(string cloudId)
        {
            var server = _serverDal.GetServerByCloudId(cloudId);
            if (server.CloudProviderId != null && server.CloudProviderId > 0)
                server.CloudProvider = _cloudProviderManager.GetCloudProvider(server.CloudProviderId ?? 0);
            return server;
        }

        /// <summary>
        ///     Get all servers.
        /// </summary>
        /// <returns></returns>
        public ICollection<Server> GetServers()
        {
            var servers = _serverDal.GetServers();
            foreach (var server in servers)
                if (server.CloudProviderId != null && server.CloudProviderId > 0)
                    server.CloudProvider = _cloudProviderManager.GetCloudProvider(server.CloudProviderId ?? 0);
            return servers;
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