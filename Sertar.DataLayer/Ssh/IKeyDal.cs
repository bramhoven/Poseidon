using System;
using System.Collections.Generic;
using Sertar.Models.Ssh;

namespace Sertar.DataLayer.Ssh
{
    public interface IKeyDal
    {
        #region Methods

        /// <summary>
        ///     Deletes a key from the store by id.
        /// </summary>
        /// <param name="id">The id of the key to delete</param>
        /// <returns></returns>
        void DeleteKey(Guid id);

        /// <summary>
        ///     Deletes a key from the store.
        /// </summary>
        /// <param name="key">The key to delete</param>
        /// <returns></returns>
        void DeleteKey(SshKey sshKey);

        /// <summary>
        ///     Gets a key from the store.
        /// </summary>
        /// <param name="id">The key id</param>
        /// <returns></returns>
        SshKey GetKey(Guid id);

        /// <summary>
        ///     Gets all the ssh keys.
        /// </summary>
        /// <returns></returns>
        ICollection<SshKey> GetKeys();

        /// <summary>
        ///     Inserts a new key into the store.
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns></returns>
        void InsertKey(SshKey key);

        /// <summary>
        ///     Updates a key in the store.
        /// </summary>
        /// <param name="key">The key to update</param>
        /// <returns></returns>
        void UpdateKey(SshKey key);

        #endregion
    }
}