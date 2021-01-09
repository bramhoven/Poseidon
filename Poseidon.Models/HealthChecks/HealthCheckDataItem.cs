using FaunaDB.Types;

namespace Poseidon.Models.HealthChecks
{
    public class HealthCheckDataItem
    {
        #region Properties

        /// <summary>
        ///     Gets the data.
        /// </summary>
        [FaunaField("data")]
        public int Data { get; set; }

        /// <summary>
        ///     The name of this health check data,
        /// </summary>
        [FaunaField("name")]
        public string Name { get; set; }

        #endregion
    }
}