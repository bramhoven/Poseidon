using Microsoft.EntityFrameworkCore;

namespace Sertar.DataLayer.Contexts.ServerContext
{
    public class MysqlServerContext : DbServerContext
    {
        #region Constructors

        /// <summary>
        ///     Initialize new instance of <see cref="Sertar.DataLayer.Contexts.ServerContext.MysqlServerContext" />.
        /// </summary>
        /// <param name="options">The db context options</param>
        public MysqlServerContext(DbContextOptions<MysqlServerContext> options) : base(options)
        {
        }

        #endregion
    }
}