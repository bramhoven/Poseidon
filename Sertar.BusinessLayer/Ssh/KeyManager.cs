using System;
using NLog;
using Sertar.DataLayer.Ssh;
using Sertar.Models.Ssh;

namespace Sertar.BusinessLayer.Ssh
{
    public class KeyManager
    {
        #region Fields

        private ILogger _logger = LogManager.GetCurrentClassLogger();
        private IKeyDal _keyDal;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of <see cref="KeyManager" />
        /// </summary>
        /// <param name="keyDal"></param>
        public KeyManager(IKeyDal keyDal)
        {
            _keyDal = keyDal;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Deletes a key from the store by id.
        /// </summary>
        /// <param name="id">The id of the key to delete</param>
        /// <returns></returns>
        public bool DeleteKey(Guid id)
        {
            try
            {
                _keyDal.DeleteKey(id);
                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return false;
            }
        }

        /// <summary>
        ///     Deletes a key from the store.
        /// </summary>
        /// <param name="key">The key to delete</param>
        /// <returns></returns>
        public bool DeleteKey(SshKey key)
        {
            try
            {
                _keyDal.DeleteKey(key);
                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return false;
            }
        }

        /// <summary>
        ///     Gets a key from the store.
        /// </summary>
        /// <param name="id">The key id</param>
        /// <returns></returns>
        public SshKey GetKey(Guid id)
        {
            try
            {
                return _keyDal.GetKey(id);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return null;
            }
        }

        /// <summary>
        ///     Inserts a new key into the store.
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns></returns>
        public bool InsertKey(SshKey key)
        {
            try
            {
                _keyDal.InsertKey(key);
                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return false;
            }
        }

        /// <summary>
        ///     Updates a key in the store.
        /// </summary>
        /// <param name="key">The key to update</param>
        /// <returns></returns>
        public bool UpdateKey(SshKey key)
        {
            try
            {
                _keyDal.UpdateKey(key);
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