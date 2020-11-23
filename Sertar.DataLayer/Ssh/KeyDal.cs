using System;
using System.Collections.Generic;
using System.Linq;
using Sertar.DataLayer.Contexts.ServerContext;
using Sertar.Models.Ssh;

namespace Sertar.DataLayer.Ssh
{
    public class KeyDal : IKeyDal
    {
        #region Fields

        /// <summary>
        ///     The server database context.
        /// </summary>
        private readonly DbServerContext _serverContext;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of <see cref="KeyDal" />
        /// </summary>
        /// <param name="serverContext"></param>
        public KeyDal(DbServerContext serverContext)
        {
            _serverContext = serverContext;
        }

        #endregion

        #region Methods

        public void DeleteKey(Guid id)
        {
            var sshKey = GetKey(id);
            DeleteKey(sshKey);
        }

        public void DeleteKey(SshKey sshKey)
        {
            _serverContext.SshKeys.Remove(sshKey);
            _serverContext.SaveChanges();
        }

        public SshKey GetKey(Guid id)
        {
            return _serverContext.SshKeys.FirstOrDefault(key => key.Id == id);
        }

        public ICollection<SshKey> GetKeys()
        {
            return _serverContext.SshKeys.ToList();
        }

        public void InsertKey(SshKey key)
        {
            _serverContext.SshKeys.Add(key);
            _serverContext.SaveChanges();
        }

        public void UpdateKey(SshKey key)
        {
            _serverContext.SshKeys.Attach(key);
            _serverContext.SaveChanges();
        }

        #endregion
    }
}