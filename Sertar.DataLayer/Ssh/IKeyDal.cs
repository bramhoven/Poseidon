using System;
using Sertar.Models.Ssh;

namespace Sertar.DataLayer.Ssh
{
    public interface IKeyDal
    {
        /// <summary>
        ///     Deletes a key from the store.
        /// </summary>
        /// <param name="id">The id of the key to delete</param>
        /// <returns></returns>
        bool DeleteKey(Guid id);

        /// <summary>
        ///     Gets a key from the store.
        /// </summary>
        /// <param name="id">The key id</param>
        /// <returns></returns>
        SshKey GetKey(Guid id);

        /// <summary>
        ///     Inserts a new key into the store.
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns></returns>
        bool InsertKey(SshKey key);

        /// <summary>
        ///     Updates a key in the store.
        /// </summary>
        /// <param name="key">The key to update</param>
        /// <returns></returns>
        SshKey UpdateKey(SshKey key);
    }
}