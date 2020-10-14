using Sertar.BusinessLayer.Authentication;
using Sertar.DataLayer.Users;
using Sertar.Models.Users;

namespace Sertar.BusinessLayer.Users
{
    public class UserManager
    {
        #region Fields

        /// <summary>
        ///     The authorization manager to user to authenticate the user.
        /// </summary>
        private readonly AuthenticationManager _authenticationManager;

        /// <summary>
        ///     The user data access layer object.
        /// </summary>
        private readonly IUserDal _userDal;

        #endregion

        #region Constructors

        public UserManager(IUserDal userDal, AuthenticationManager authenticationManager)
        {
            _userDal = userDal;
            _authenticationManager = authenticationManager;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Login a user.
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        public bool Login(string username, string password)
        {
            return _authenticationManager.AuthenticateIdentity(username, password);
        }

        /// <summary>
        ///     Register a user.
        /// </summary>
        /// <param name="user">The user to register</param>
        /// <returns></returns>
        public bool RegisterUser(User user)
        {
            if (GetUser(user.Username) == null)
                return _userDal.InsertUser(user);

            return false;
        }

        /// <summary>
        /// Get user by username.
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <returns>The user if found, else null</returns>
        public User GetUser(string username)
        {
            return _userDal.GetUserByUsername(username);
        }

        #endregion
    }
}