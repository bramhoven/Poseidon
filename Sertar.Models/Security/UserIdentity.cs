using System.Security.Principal;
using Sertar.Models.Users;

namespace Sertar.Models.Security
{
    public class UserIdentity : IIdentity
    {
        #region Properties

        /// <summary>
        ///     They method that is used for authentication.
        /// </summary>
        public string AuthenticationType { get; }

        /// <summary>
        ///     Whether or not the user is authenticated.
        /// </summary>
        public bool IsAuthenticated  => User != null;

        /// <summary>
        ///     The name of this user.
        /// </summary>
        public string Name => User.Username;

        /// <summary>
        ///     The user that is linked to this identity.
        /// </summary>
        public User User { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of <see cref="Sertar.Models.Security.UserIdentity" />
        /// </summary>
        public UserIdentity(string authenticationType, User user)
        {
            AuthenticationType = authenticationType;
            User = user;
        }

        #endregion
    }
}