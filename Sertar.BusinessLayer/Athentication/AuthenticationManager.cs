using Sertar.DataLayer.Authentication;

namespace Sertar.BusinessLayer
{
    public class AuthenticationManager
    {
        #region Fields

        /// <summary>
        ///     The authentication datalayer object.
        /// </summary>
        private readonly IAuthenticationDal _authenticationDal;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialize the AuthenticationManager.
        /// </summary>
        /// <param name="authenticationDal">The authentication provider to use</param>
        public AuthenticationManager(IAuthenticationDal authenticationDal)
        {
            _authenticationDal = authenticationDal;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Authenticate a key.
        /// </summary>
        /// <param name="key">The key to authorize</param>
        /// <returns></returns>
        public bool Authenticate(string key)
        {
            _authenticationDal.Authenticate(key);
        }

        /// <summary>
        ///     Authenticate an identity,
        /// </summary>
        /// <param name="identifier">The identity name</param>
        /// <param name="password">The identities' password</param>
        /// <returns></returns>
        public bool AuthenticateIdentity(string identifier, string password)
        {
            _authenticationDal.AuthenticateIdentity(identifier, password);
        }

        #endregion
    }
}