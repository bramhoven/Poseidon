using System;
using Sertar.Enums.Ssh;

namespace Sertar.Models.Ssh
{
    public class SshKey
    {
        #region Properties

        /// <summary>
        ///     The key format.
        /// </summary>
        public SshKeyFormat Format { get; set; }

        /// <summary>
        ///     The id of this key.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        ///     The name of this key.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The private key.
        /// </summary>
        public string PrivateKey { get; set; }

        /// <summary>
        ///     The public key.
        /// </summary>
        public string PublicKey { get; set; }

        #endregion
    }
}