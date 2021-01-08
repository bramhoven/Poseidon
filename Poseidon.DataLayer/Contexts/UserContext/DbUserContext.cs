using Microsoft.EntityFrameworkCore;
using Poseidon.Models.Users;

namespace Poseidon.DataLayer.Contexts.UserContext
{
    public class DbUserContext : DbContext
    {
        #region Properties

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialize new instance of <see cref="DbUserContext" />.
        /// </summary>
        /// <param name="options">The db context options</param>
        public DbUserContext(DbContextOptions<DbUserContext> options) : base(options)
        {
        }

        /// <summary>
        ///     Initialize new instance of <see cref="DbUserContext" /> with not specific
        ///     DbContextOptions for subclasses.
        /// </summary>
        /// <param name="options">The db context options</param>
        public DbUserContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        ///     Initialize new instance of <see cref="DbUserContext" />
        /// </summary>
        public DbUserContext()
        {
        }

        #endregion
    }
}