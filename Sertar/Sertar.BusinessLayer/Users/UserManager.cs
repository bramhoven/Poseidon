using Sertar.DataLayer.Users;

namespace Sertar.BusinessLayer.Users
{
    public class UserManager
    {
        #region Fields

        /// <summary>
        /// The authorization manager to user to authenticate the user.
        /// </summary>
        private readonly IAuthorizationManager _authorizationManager;

        /// <summary>
        /// The user data access layer object.
        /// </summary>
        private readonly IUserDal _userDal;

        #endregion

        #region Constructors

        public UserManager(IUserDal userDal, IAuthorizationManager authorizationManager)
        {
            _userDal = userDal;
            _authorizationManager = authorizationManager;
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
            return _authorizationManager.AuthorizeIdentity(username, password);
        }

        #endregion
    }
}