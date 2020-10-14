using Sertar.BusinessLayer.Users;
using Sertar.DataLayer.Authentication;
using Sertar.Helpers.Cryptography;

namespace Sertar.BusinessLayer.Authentication
{
    public class UserAuthenticationManager : AuthenticationManager
    {
        #region Fields

        /// <summary>
        ///     The user manager object.
        /// </summary>
        private readonly UserManager _userManager;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialize new instance of <see cref="Sertar.BusinessLayer.Authentication.AuthenticationManager" />.
        /// </summary>
        /// <param name="userManager">The user manager to use</param>
        public UserAuthenticationManager(UserManager userManager)
        {
            _userManager = userManager;
        }

        #endregion

        #region Methods

        public override bool AuthenticateIdentity(string identifier, string password)
        {
            var user = _userManager.GetUser(identifier);
            return user != null && PasswordHelper.ValidatePassword(password, user.Password);
        }

        #endregion
    }
}