using Microsoft.EntityFrameworkCore;

namespace Sertar.DataLayer.Contexts
{
    public class MysqlUserContext : DbUserContext
    {
        #region Constructors

        /// <summary>
        ///     Initialize new instance of <see cref="Sertar.DataLayer.Contexts.MysqlUserContext" />.
        /// </summary>
        /// <param name="options">The db context options</param>
        public MysqlUserContext(DbContextOptions<MysqlUserContext> options) : base(options)
        {
        }

        #endregion
    }
}