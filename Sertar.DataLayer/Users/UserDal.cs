using System;
using System.Linq;
using NLog;
using Sertar.DataLayer.Contexts.UserContext;
using Sertar.Models.Users;

namespace Sertar.DataLayer.Users
{
    public class UserDal : IUserDal
    {
        #region Fields

        /// <summary>
        ///     The logger.
        /// </summary>
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     The user database context.
        /// </summary>
        private readonly DbUserContext _userContext;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of <see cref="Sertar.DataLayer.Users.UserDal" />.
        /// </summary>
        /// <param name="userContext"></param>
        public UserDal(DbUserContext userContext)
        {
            _userContext = userContext;
        }

        #endregion

        #region Methods

        public bool DeleteUser(User user)
        {
            try
            {
                _userContext.Users.Remove(user);
                _userContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return false;
            }
        }

        public User GetUserByUsername(string username)
        {
            return _userContext.Users.First(user => user.Username.Equals(username));
        }

        public bool InsertUser(User user)
        {
            try
            {
                _userContext.Users.Add(user);
                _userContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                _userContext.Users.Attach(user);
                _userContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return false;
            }
        }

        #endregion
    }
}