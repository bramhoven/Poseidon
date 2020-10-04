using System.Collections.Generic;

namespace Sertar.BusinessLayer.Users
{
    public class User
    {
        #region Fields

        /// <summary>
        ///     The email address of this user.
        /// </summary>
        public string Email;

        /// <summary>
        ///     The hashed password of this user.
        /// </summary>
        public string Password;

        /// <summary>
        ///     The roles that this user has.
        /// </summary>
        public List<Role> Roles;

        /// <summary>
        ///     The username of this user.
        /// </summary>
        public string Username;

        /// <summary>
        /// Whether this user is active or not.
        /// </summary>
        public bool Active;

        #endregion
    }
}