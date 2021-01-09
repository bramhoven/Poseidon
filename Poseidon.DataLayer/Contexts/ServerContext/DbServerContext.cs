using Microsoft.EntityFrameworkCore;
using Poseidon.Models.Cloud;
using Poseidon.Models.HealthChecks;
using Poseidon.Models.Security;
using Poseidon.Models.Servers;

namespace Poseidon.DataLayer.Contexts.ServerContext
{
    public class DbServerContext : DbContext
    {
        #region Properties

        public DbSet<CloudProvider> CloudProviders { get; set; }
        public DbSet<HealthCheckProperties> HealthCheckProperties { get; set; }
        public DbSet<IpAddress> IpAddresses { get; set; }
        public DbSet<PublicSshKey> PublicSshKeys { get; set; }

        public DbSet<Server> Servers { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialize new instance of <see cref="DbServerContext" />.
        /// </summary>
        /// <param name="options">The db context options</param>
        public DbServerContext(DbContextOptions<DbServerContext> options) : base(options)
        {
        }

        /// <summary>
        ///     Initialize new instance of <see cref="DbServerContext" /> with not specific
        ///     DbContextOptions for subclasses.
        /// </summary>
        /// <param name="options">The db context options</param>
        public DbServerContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        ///     Initialize new instance of <see cref="DbServerContext" />
        /// </summary>
        public DbServerContext()
        {
        }

        #endregion
    }
}