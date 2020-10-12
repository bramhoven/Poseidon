namespace Sertar.DataLayer.Authentication
{
    public interface IAuthenticationDal
    {
        #region Methods

        /// <summary>
        ///     Authenticate a key.
        /// </summary>
        /// <param name="key">The key to authorize</param>
        /// <returns></returns>
        bool Authenticate(string key);

        /// <summary>
        ///     Authenticate an identity,
        /// </summary>
        /// <param name="identifier">The identity name</param>
        /// <param name="password">The identities' password</param>
        /// <returns></returns>
        bool AuthenticateIdentity(string identifier, string password);

        #endregion
    }
}