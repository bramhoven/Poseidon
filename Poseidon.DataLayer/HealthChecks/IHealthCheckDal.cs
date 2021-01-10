using System.Collections.Generic;
using Poseidon.Models.HealthChecks;

namespace Poseidon.DataLayer.HealthChecks
{
    public interface IHealthCheckDal
    {
        #region Methods

        /// <summary>
        ///     Adds a health check to the database.
        /// </summary>
        /// <param name="healthCheck">The health check object</param>
        /// <returns></returns>
        bool AddHealthCheck(HealthCheck healthCheck);

        /// <summary>
        ///     Get all health checks from the database.
        /// </summary>
        /// <returns></returns>
        ICollection<HealthCheck> GetHealthChecks();

        /// <summary>
        ///     Get all health checks for a specific server from the database.
        /// </summary>
        /// <returns></returns>
        ICollection<HealthCheck> GetHealthChecks(string serverId);

        #endregion
    }
}