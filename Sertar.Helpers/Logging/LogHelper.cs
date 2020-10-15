using NLog;
using NLog.Web;

namespace Sertar.Helpers.Logging
{
    public static class LogHelper
    {
        #region Methods

        #region Static Methods

        /// <summary>
        ///     Get a configured logger.
        /// </summary>
        /// <returns></returns>
        public static Logger GetLogger()
        {
            return NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
        }

        #endregion

        #endregion
    }
}