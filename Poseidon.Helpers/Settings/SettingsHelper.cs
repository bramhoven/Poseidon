using Microsoft.Extensions.Configuration;

namespace Poseidon.Helpers.Settings
{
    public class SettingsHelper
    {
        #region Fields

        private static IConfiguration _configuration;

        #endregion

        #region Properties

        /// <summary>
        ///     The digital ocean api key.
        /// </summary>
        public static string DigitalOceanApiKey =>
            _configuration.GetValue<string>("CloudCredentials:DigitalOcean:ApiKey");

        /// <summary>
        ///     Gets whether digital ocean should be mocked.
        /// </summary>
        public static bool MockDigitalOcean => _configuration.GetValue<bool>("Mocked:DigitalOcean");

        /// <summary>
        ///     Gets whether ovh should be mocked.
        /// </summary>
        public static bool MockOvh => _configuration.GetValue<bool>("Mocked:Ovh");

        /// <summary>
        ///     The ovh application key.
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
        ///     Initializes a new instance of <see cref="SettingsHelper" />.
        /// </summary>
        /// <param name="configuration"></param>
        public SettingsHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion
    }
}