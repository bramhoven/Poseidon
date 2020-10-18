using System;
using System.Collections.Generic;
using System.Text;

namespace Sertar.Models.Servers
{
    public class IpAddress
    {
        /// <summary>
        /// The id of the ip address.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The optional name of the ip address.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The ip address.
        /// </summary>
        public string Ip { get; set; }

    }
}
