using System;
using Sertar.BusinessLayer.Ssh.Models;

namespace Sertar.BusinessLayer.Ssh.Providers
{
    public interface ISshKeyProvider
    {
        #region Methods

        /// <summary>
        ///     Deletes the ssh key.
        /// </summary>
        /// <param name="id">The id of the ssh key</param>
        /// <returns></returns>
        bool DeleteSshKey(Guid id);

        /// <summary>
        ///     Gets the ssh key.
        /// </summary>
        /// <param name="id">The id of the ssh key</param>
        /// <returns></returns>
        SshKey GetSshKey(Guid id);

        /// <summary>
        ///     Inserts the ssh key.
        /// </summary>
        /// <param name="sshKey">The ssh key</param>
        /// <returns></returns>
        SshKey InsertSshKey(SshKey sshKey);

        /// <summary>
        ///     Updates the ssh key.
        /// </summary>
        /// <param name="sshKey"></param>
        /// <returns></returns>
        SshKey UpdateSshKey(SshKey sshKey);

        #endregion
    }
}