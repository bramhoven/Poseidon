using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Sertar.Helpers.Cryptography;

namespace Sertar.Helpers.Tests.Cryptography
{
    [TestFixture]
    public class PasswordHelperTest
    {
        /// <summary>
        /// Test whether the hashing of the password works.
        /// </summary>
        [Test]
        public void HashPassword_Test()
        {
            var password = "SuperSecurePassword";
            var hashedPassword = PasswordHelper.HashPassword(password);

            Assert.AreNotEqual(hashedPassword, password);
        }

        /// <summary>
        /// Test whether the password is correctly validated.
        /// </summary>
        [Test]
        public void ValidatePassword_PasswordsMatch()
        {
            var password = "SuperSecurePassword";
            var hashedPassword = PasswordHelper.HashPassword(password);

            var result = PasswordHelper.ValidatePassword(password, hashedPassword);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test whether the password is correctly validated.
        /// </summary>
        [Test]
        public void ValidatePassword_PasswordsDoNotMatch()
        {
            var password = "SuperSecurePassword";
            var hashedPassword = PasswordHelper.HashPassword(password);

            var checkPassword = "AnotherPassword";
            var result = PasswordHelper.ValidatePassword(checkPassword, hashedPassword);

            Assert.IsFalse(result);
        }
    }
}
