using System.Collections.Generic;

namespace Poseidon.Models.Users
{
    public class User
    {
        #region Properties

        /// <summary>
        ///     Whether this user is active or not.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        ///     The email address of this user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     The Id of this user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The hashed password of this user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     The roles that this user has.
        /// </summary>
        public List<Role> Roles { get; set; }

        /// <summary>
        ///     The username of this user.
        /// </summary>
        public string Username { get; set; }

        #endregion
    }
}