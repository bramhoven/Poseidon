using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NLog;
using Poseidon.DataLayer.Contexts.ServerContext;
using Poseidon.Models.Servers;

namespace Poseidon.DataLayer.Servers
{
    public class ServerDal : IServerDal
    {
        #region Fields

        /// <summary>
        ///     The logger.
        /// </summary>
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     The server database context.
        /// </summary>
        private readonly DbServerContext _serverContext;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of <see cref="ServerDal" />
        /// </summary>
        /// <param name="serverContext"></param>
        public ServerDal(DbServerContext serverContext)
        {
            _serverContext = serverContext;
        }

        #endregion

        #region Methods

        public bool DeleteServer(Server server)
        {
            try
            {
                if (server.IpAddresses != null)
                    _serverContext.IpAddresses.RemoveRange(server.IpAddresses);

                if (server.PublicSshKey != null)
                    _serverContext.PublicSshKeys.Remove(server.PublicSshKey);

                if (server.HealthCheckProperties != null)
                    _serverContext.HealthCheckProperties.Remove(server.HealthCheckProperties);

                _serverContext.Servers.Remove(server);
                _serverContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return false;
            }
        }

        public Server GetServer(Guid id)
        {
            try
            {
                return _serverContext.Servers
                    .Include(s => s.HealthCheckProperties)
                    .Include(s => s.PublicSshKey)
                    .Include(s => s.CloudProvider)
                    .Include(s => s.IpAddresses)
                    .FirstOrDefault(server => server.Id == id);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return null;
            }
        }

        public Server GetServerByCloudId(string cloudId)
        {
            try
            {
                return _serverContext.Servers
                    .Include(s => s.HealthCheckProperties)
                    .Include(s => s.PublicSshKey)
                    .Include(s => s.CloudProvider)
                    .Include(s => s.IpAddresses)
                    .FirstOrDefault(server => server.CloudId.Equals(cloudId));
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return null;
            }
        }

        public DbServerContext GetServerContext()
        {
            return _serverContext;
        }

        public ICollection<Server> GetServers()
        {
            return _serverContext.Servers
                .Include(s => s.HealthCheckProperties)
                .Include(s => s.PublicSshKey)
                .Include(s => s.CloudProvider)
                .Include(s => s.IpAddresses)
                .ToList();
        }

        public bool InsertServer(Server server)
        {
            try
            {
                if (server.CloudProvider != null)
                    _serverContext.CloudProviders.Attach(server.CloudProvider);

                _serverContext.Servers.Add(server);
                _serverContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return false;
            }
        }

        public bool UpdateServer(Server server)
        {
            try
            {
                _serverContext.Servers.Attach(server);
                _serverContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return false;
            }
        }

        #endregion
    }
}