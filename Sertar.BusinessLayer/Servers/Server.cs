using System.Collections.Generic;
using Sertar.BusinessLayer.Scripts;

namespace Sertar.BusinessLayer.Servers
{
    public class Server
    {
        #region Fields

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