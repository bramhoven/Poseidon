using System;
using System.Security.Cryptography;

namespace Sertar.Helpers.Cryptography
{
    public class PasswordHelper
    {
        #region Methods

        /// <summary>
        ///     Hash a password.
        /// </summary>
        /// <param name="password">The password to be hashed</param>
        /// <returns>The hashed password</returns>
        public static string HashPassword(string password)
        {
            byte[] saltBytes;
            new RNGCryptoServiceProvider().GetBytes(saltBytes = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(saltBytes, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        ///     Validate inputted password against hashed password.
        /// </summary>
        /// <param name="password">The inputted password</param>
        /// <param name="passwordHash">The hashed password</param>
        /// <returns></returns>
        public static bool ValidatePassword(string password, string passwordHash)
        {
            byte[] hashBytes = Convert.FromBase64String(passwordHash);
            
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;
            return true;
        }

        #endregion
    }
}