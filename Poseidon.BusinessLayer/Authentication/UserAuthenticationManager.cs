using System.Security.Claims;
using System.Security.Principal;
using Poseidon.BusinessLayer.Users;
using Poseidon.DataLayer.Authentication;
using Poseidon.Helpers.Cryptography;
using Poseidon.Models.Security;

namespace Poseidon.BusinessLayer.Authentication
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
        /// </summary>
        /// <param name="userManager">The user manager to use</param>
        public UserAuthenticationManager(UserManager userManager)
        {
            _userManager = userManager;
        }

        #endregion

        #region Methods

        public override IIdentity AuthenticateIdentity(string identifier, string password)
        {
            var user = _userManager.GetUser(identifier);
            if (user != null && PasswordHelper.ValidatePassword(password, user.Password))
                return new UserIdentity("UserLogin", user);

            return null;
        }

        #endregion
    }
}