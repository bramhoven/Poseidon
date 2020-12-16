using Microsoft.EntityFrameworkCore;

namespace Poseidon.DataLayer.Contexts.ServerContext
{
    public class PostgresServerContext : DbServerContext
    {
        #region Constructors

        /// <summary>
        ///     Initialize new instance of <see cref="PostgresServerContext" />.
        /// </summary>
        /// <param name="options">The db context options</param>
        public PostgresServerContext(DbContextOptions<PostgresServerContext> options) : base(options)
        {
        }

        #endregion
    }
}