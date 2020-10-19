using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using Sertar.DataLayer.Contexts.ServerContext;
using Sertar.Models.Servers;

namespace Sertar.DataLayer.Servers
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
        ///     Initializes a new instance of <see cref="Sertar.DataLayer.Servers.ServerDal" />
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

        public ICollection<Server> GetServers()
        {
            return _serverContext.Servers.ToList();
        }

        public bool InsertServer(Server server)
        {
            try
            {
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