using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using NLog;
using Ovh.Api;
using Sertar.DataLayer.Cloud.Models.Ovh;
using Sertar.Helpers.Settings;
using Sertar.Models.Cloud;
using Sertar.Models.Cloud.Ovh;
using Sertar.Models.Servers;

namespace Sertar.DataLayer.Cloud
{
    public class OvhCloudDal : ICloudDal
    {
        #region Fields

        /// <summary>
        ///     The ovh api client.
        /// </summary>
        private readonly Client _client;

        /// <summary>
        ///     The logger.
        /// </summary>
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of <see cref="Sertar.DataLayer.Cloud.OvhCloudDal" />.
        /// </summary>
        public OvhCloudDal()
        {
            if (string.IsNullOrWhiteSpace(SettingsHelper.OvhApplicationKey))
                throw new ArgumentException("The ApplicationKey is not set in the configurations.", nameof(SettingsHelper.OvhApplicationKey));

            if (string.IsNullOrWhiteSpace(SettingsHelper.OvhApplicationSecret))
                throw new ArgumentException("The ApplicationSecret is not set in the configurations.", nameof(SettingsHelper.OvhApplicationSecret));

            if (string.IsNullOrWhiteSpace(SettingsHelper.OvhCustomerKey))
                throw new ArgumentException("The CustomerKey is not set in the configurations.", nameof(SettingsHelper.OvhCustomerKey));

            _client = new Client("ovh-eu", SettingsHelper.OvhApplicationKey, SettingsHelper.OvhApplicationSecret,
                SettingsHelper.OvhCustomerKey);
        }

        #endregion

        #region Methods

        public Server CreateServer(string name, string size, string image, string region)
        {
            if(string.IsNullOrWhiteSpace(SettingsHelper.OvhProject))
                throw new ArgumentException(nameof(SettingsHelper.OvhProject));

            var url = $"/cloud/project/{SettingsHelper.OvhProject}/instance";
            var requestData = new OvhInstanceCreationRequestData()
            {
                FlavorId = size,
                Name = name,
                ImageId = image,
                Region = region
            };

            try
            {
                var ovhServer = _client.PostAsync<OvhServer>(url, requestData).GetAwaiter().GetResult();
                var server = new Server()
                {
                    CloudId = ovhServer.Id,
                    Name = ovhServer.Name
                };

                return server;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return null;
            }
        }

        public ICollection<InstanceImageBase> GetAvailableImages()
        {
            var url = $"/cloud/project/{SettingsHelper.OvhProject}/image";

            try
            {
                var result = _client.GetAsync<ICollection<OvhImage>>(url).GetAwaiter().GetResult();
                return result.Select(image => new OvhInstanceImage(image)).Cast<InstanceImageBase>().ToList();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return new List<InstanceImageBase>();
            }
        }

        public ICollection<InstanceSizeBase> GetAvailableSizes()
        {
            var url = $"/cloud/project/{SettingsHelper.OvhProject}/flavor";

            try
            {
                var result = _client.GetAsync<ICollection<OvhFlavor>>(url).GetAwaiter().GetResult();
                return result.Select(flavor => new OvhInstanceSize(flavor)).Cast<InstanceSizeBase>().ToList();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return new List<InstanceSizeBase>();
            }
        }

        #endregion
    }
}