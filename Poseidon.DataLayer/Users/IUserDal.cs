using Poseidon.Models.Users;

namespace Poseidon.DataLayer.Users
{
    public interface IUserDal
    {
        #region Methods

        /// <summary>
        ///     Delete user.
        /// </summary>
        /// <param name="user">The user to delete</param>
        /// <returns></returns>
        bool DeleteUser(User user);


        /// <summary>
        ///     Get user by username.
        /// </summary>
        /// <param name="username">The username</param>
        /// <returns></returns>
        User GetUserByUsername(string username);

        /// <summary>
        ///     Insert user.
        /// </summary>
        /// <param name="user">The user to insert</param>
        /// <returns></returns>
        bool InsertUser(User user);

        /// <summary>
        ///     Update user.
        /// </summary>
        /// <param name="user">The user to update</param>
        /// <returns></returns>
        bool UpdateUser(User user);

        #endregion
    }
}