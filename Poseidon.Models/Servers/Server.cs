using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Poseidon.Models.Cloud;
using Poseidon.Models.Scripts;
using Poseidon.Models.Security;

namespace Poseidon.Models.Servers
{
    public class Server
    {
        #region Properties

        /// <summary>
        ///     The id given to this server by the cloud provider.
        /// </summary>
        public string CloudId { get; set; }

        /// <summary>
        ///     The cloud provider where this server is hosted.
        /// </summary>
        [NotMapped]
        public CloudProvider CloudProvider { get; set; }

        /// <summary>
        ///     The cloud provider id.
        /// </summary>
        public int CloudProviderId
        {
            get
            {
                return CloudProvider?.Id ?? 0;
            }
        }

        /// <summary>
        ///     The id given by Sertar.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        ///     The installation script for this server.
        /// </summary>
        [NotMapped]
        public ScriptBase InstallationScript { get; set; }

        /// <summary>
        ///     The location of the installation script.
        /// </summary>
        public string InstallationScriptLocation { get; set; }

        /// <summary>
        ///     All the IP addresses that are bound to this server.
        /// </summary>
        public ICollection<IpAddress> IpAddresses { get; set; }

        /// <summary>
        ///     The main IP Address of this server.
        /// </summary>
        public string MainIpAddress { get; set; }

        /// <summary>
        ///     The name of the server.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The public ssh keys connected to this server.
        /// </summary>
        public PublicSshKey PublicSshKey { get; set; }

        #endregion
    }
}