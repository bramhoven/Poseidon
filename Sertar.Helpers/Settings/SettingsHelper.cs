using Microsoft.Extensions.Configuration;

namespace Sertar.Helpers.Settings
{
    public class SettingsHelper
    {
        #region Fields

        private static IConfiguration _configuration;

        #endregion

        #region Properties

        /// <summary>
        ///     The ovvh application key.
        /// </summary>
        public static string OvhApplicationKey =>
            _configuration.GetValue<string>("CloudCredentials:Ovh:ApplicationKey");

        /// <summary>
        ///     The ovh application secret.
        /// </summary>
        public static string OvhApplicationSecret =>
            _configuration.GetValue<string>("CloudCredentials:Ovh:ApplicationSecret");


        /// <summary>
        ///     The ovh customer key.
        /// </summary>
        public static string OvhCustomerKey => _configuration.GetValue<string>("CloudCredentials:Ovh:CustomerKey");

        /// <summary>
        ///     The ovh project id.
        /// </summary>
        public static string OvhProject => _configuration.GetValue<string>("CloudCredentials:Ovh:Project");

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of <see cref="Sertar.Helpers.Settings.SettingsHelper" />.
        /// </summary>
        /// <param name="configuration"></param>
        public SettingsHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion
    }
}