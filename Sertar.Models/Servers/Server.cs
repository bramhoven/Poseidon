using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sertar.Models.Scripts;

namespace Sertar.Models.Servers
{
    public class Server
    {
        #region Properties

        /// <summary>
        ///     The id given to this server by the cloud provider.
        /// </summary>
        public string CloudId { get; set; }

        /// <summary>
        ///     The id given by Sertar.
        /// </summary>
        public Guid Id { get; set; }

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

        #endregion
    }
}