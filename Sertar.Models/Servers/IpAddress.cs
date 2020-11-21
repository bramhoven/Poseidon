using System;

namespace Sertar.Models.Servers
{
    public class IpAddress
    {
        #region Properties

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
        ///     The ip version.
        /// </summary>
        public int Version { get; set; }

        #endregion
    }
}