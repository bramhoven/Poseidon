using Poseidon.Models.Enums;
using Poseidon.Models.Servers;

namespace Poseidon.Models.HealthChecks
{
    public class HealthCheckProperties
    {
        #region Properties

        /// <summary>
        ///     The path where the health check page is.
        /// </summary>
        public string HealthCheckPath { get; set; }

        /// <summary>
        ///     The id of this health check property.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The protocol that should be used to access health check page.
        /// </summary>
        public ProtocolType Protocol { get; set; }

        #endregion
    }
}