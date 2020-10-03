namespace Sertar.BusinessLayer
{
    public interface IAuthorizationManager
    {
        #region Methods

        /// <summary>
        ///     Authorize a key.
        /// </summary>
        /// <param name="key">The key to authorize</param>
        /// <returns></returns>
        bool Authorize(string key);

        /// <summary>
        ///     Authorize an identity,
        /// </summary>
        /// <param name="identifier">The identity name</param>
        /// <param name="password">The identities' password</param>
        /// <returns></returns>
        bool AuthorizeIdentity(string identifier, string password);

        #endregion  
    }
}