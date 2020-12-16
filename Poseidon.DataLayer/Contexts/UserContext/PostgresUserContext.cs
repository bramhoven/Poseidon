using Microsoft.EntityFrameworkCore;

namespace Poseidon.DataLayer.Contexts.UserContext
{
    public class PostgresUserContext : DbUserContext
    {
        #region Constructors

        /// <summary>
        ///     Initialize new instance of <see cref="PostgresUserContext" />.
        /// </summary>
        /// <param name="options">The db context options</param>
        public PostgresUserContext(DbContextOptions<PostgresUserContext> options) : base(options)
        {
        }

        #endregion
    }
}