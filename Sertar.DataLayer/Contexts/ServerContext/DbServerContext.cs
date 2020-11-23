using Microsoft.EntityFrameworkCore;
using Sertar.Models.Servers;
using Sertar.Models.Ssh;

namespace Sertar.DataLayer.Contexts.ServerContext
{
    public class DbServerContext : DbContext
    {
        #region Properties

        public DbSet<Server> Servers { get; set; }
        public DbSet<SshKey> SshKeys { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialize new instance of <see cref="Sertar.DataLayer.Contexts.ServerContext.DbServerContext" />.
        /// </summary>
        /// <param name="options">The db context options</param>
        public DbServerContext(DbContextOptions<DbServerContext> options) : base(options)
        {
        }

        /// <summary>
        ///     Initialize new instance of <see cref="Sertar.DataLayer.Contexts.ServerContext.DbServerContext" /> with not specific
        ///     DbContextOptions for subclasses.
        /// </summary>
        /// <param name="options">The db context options</param>
        public DbServerContext(DbContextOptions options) : base(options)
        {
        }

        #endregion
    }
}