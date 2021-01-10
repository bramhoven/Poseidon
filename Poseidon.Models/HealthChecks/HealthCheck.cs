using System;
using System.Collections.Generic;
using FaunaDB.Types;
using Poseidon.Models.Servers;

namespace Poseidon.Models.HealthChecks
{
    public class HealthCheck
    {
        #region Fields

        private Server _server;

        #endregion

        #region Properties

        /// <summary>
        ///     The date at which this health check was performed.
        /// </summary>
        [FaunaField("date")]
        public DateTime Date { get; set; }

        /// <summary>
        ///     The health check custom data items.
        /// </summary
        public ICollection<HealthCheckDataItem> DataItems { get; set; }

        /// <summary>
        ///     The id of the health check.
        /// </summary>
        [FaunaField("id")]
        public string Id { get; set; }

        /// <summary>
        ///     The response time of the health check.
        /// </summary>
        [FaunaField("responseTime")]
        public int ResponseTime { get; set; }

        /// <summary>
        ///     The server where this health check is from.
        /// </summary>
        public Server Server
        {
            get => _server;
            set
            {
                _server = value;
                ServerId = _server?.Id.ToString() ?? Guid.NewGuid().ToString();
            }
        }

        /// <summary>
        ///     The server id of the server where this health check is from.
        /// </summary>
        [FaunaField("serverId")]
        public string ServerId { get; set; }

        #endregion
    }
}