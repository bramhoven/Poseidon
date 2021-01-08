using Microsoft.EntityFrameworkCore;

namespace Poseidon.DataLayer.Contexts.ServerContext
{
    public class MysqlServerContext : DbServerContext
    {
        #region Constructors

        /// <summary>
        ///     Initialize new instance of <see cref="MysqlServerContext" />.
        /// </summary>
        /// <param name="options">The db context options</param>
        public MysqlServerContext(DbContextOptions<MysqlServerContext> options) : base(options)
        {
        }

        /// <summary>
        ///     Initialize new instance of <see cref="MysqlServerContext" />.
        /// </summary>
        public MysqlServerContext()
        {
        }

        #endregion
    }
}