using System.Collections.Generic;
using Sertar.Models.Scripts;

namespace Sertar.Models.Servers
{
    public class Server
    {
        #region Fields

        /// <summary>
        ///     The id given to this server by the cloud provider.
        /// </summary>
        public string CloudId;

        /// <summary>
        ///     The id given by Sertar.
        /// </summary>
        public string Id;

        /// <summary>
        ///     The installation script for this server.
        /// </summary>
        public ScriptBase InstallationScript;

        /// <summary>
        ///     All the IP addresses that are bound to this server.
        /// </summary>
        public List<string> IpAddresses;

        /// <summary>
        ///     The main IP Address of this server.
        /// </summary>
        public string MainIpAddress;

        #endregion
    }
}