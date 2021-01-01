using System;

namespace Poseidon.Models.Servers
{
    public class IpAddress
    {
        #region Properties

        /// <summary>
        ///     The gateway of the ip address.
        /// </summary>
        public string Gateway { get; set; }

        /// <summary>
        ///     The id of the ip address.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        ///     The ip address.
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        ///     The optional name of the ip address.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The netmask of the ip address.
        /// </summary>
        public string Netmask { get; set; }

        /// <summary>
        ///     The ip version.
        /// </summary>
        public int Version { get; set; }

        #endregion
    }
}