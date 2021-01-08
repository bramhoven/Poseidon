using Microsoft.EntityFrameworkCore;

namespace Poseidon.DataLayer.Contexts.UserContext
{
    public class MysqlUserContext : DbUserContext
    {
        #region Constructors

        /// <summary>
        ///     Initialize new instance of <see cref="MysqlUserContext" />.
        /// </summary>
        /// <param name="options">The db context options</param>
        public MysqlUserContext(DbContextOptions<MysqlUserContext> options) : base(options)
        {
        }

        /// <summary>
        ///     Initialize new instance of <see cref="MysqlUserContext" />.
        /// </summary>
        public MysqlUserContext()
        { 
        }

        #endregion
    }
}