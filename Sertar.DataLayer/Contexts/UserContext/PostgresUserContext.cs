using Microsoft.EntityFrameworkCore;

namespace Sertar.DataLayer.Contexts.UserContext
{
    public class PostgresUserContext : DbUserContext
    {
        #region Constructors

        /// <summary>
        ///     Initialize new instance of <see cref="Sertar.DataLayer.Contexts.UserContext.PostgresUserContext" />.
        /// </summary>
        /// <param name="options">The db context options</param>
        public PostgresUserContext(DbContextOptions<PostgresUserContext> options) : base(options)
        {
        }

        #endregion
    }
}