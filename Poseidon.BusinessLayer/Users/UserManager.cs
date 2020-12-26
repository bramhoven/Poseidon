using System;
using System.Security.Principal;
using NLog;
using Poseidon.BusinessLayer.Authentication;
using Poseidon.DataLayer.Users;
using Poseidon.Models.Users;

namespace Poseidon.BusinessLayer.Users
{
    public class UserManager
    {
        #region Fields

        /// <summary>
        ///     The authorization manager to user to authenticate the user.
        /// </summary>
        private readonly AuthenticationManager _authenticationManager;

        /// <summary>
        ///     The logger.
        /// </summary>
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

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
        ///     Get user by username.
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <returns>The user if found, else null</returns>
        public User GetUser(string username)
        {
            return _userDal.GetUserByUsername(username);
        }

        /// <summary>
        ///     Login a user.
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        public IIdentity Login(string username, string password)
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
            try
            {
                if (GetUser(user.Username) == null)
                {
                    _userDal.InsertUser(user);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            return false;
        }

        #endregion
    }
}