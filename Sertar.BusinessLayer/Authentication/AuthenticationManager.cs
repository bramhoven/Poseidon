﻿using System;

namespace Sertar.BusinessLayer.Authentication
{
    public class AuthenticationManager
    {
        #region Methods

        /// <summary>
        ///     Authenticate a key.
        /// </summary>
        /// <param name="key">The key to authorize</param>
        /// <returns></returns>
        public virtual bool Authenticate(string key)
        {
            throw new NotImplementedException("Authenticate method has not been implemented");
        }

        /// <summary>
        ///     Authenticate an identity,
        /// </summary>
        /// <param name="identifier">The identity name</param>
        /// <param name="password">The identities' password</param>
        /// <returns></returns>
        public virtual bool AuthenticateIdentity(string identifier, string password)
        {
            throw new NotImplementedException("AuthenticateIdentity method has not been implemented");
        }

        #endregion
    }
}