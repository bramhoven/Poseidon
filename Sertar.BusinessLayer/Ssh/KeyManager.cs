using System;
using Sertar.Models.Ssh;

namespace Sertar.BusinessLayer.Ssh
{
    public class KeyManager
    {
        #region Methods

        /// <summary>
        ///     Deletes a key from the store.
        /// </summary>
        /// <param name="id">The id of the key to delete</param>
        /// <returns></returns>
        public bool DeleteKey(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets a key from the store.
        /// </summary>
        /// <param name="id">The key id</param>
        /// <returns></returns>
        public SshKey GetKey(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Inserts a new key into the store.
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns></returns>
        public bool InsertKey(SshKey key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Updates a key in the store.
        /// </summary>
        /// <param name="key">The key to update</param>
        /// <returns></returns>
        public SshKey UpdateKey(SshKey key)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}