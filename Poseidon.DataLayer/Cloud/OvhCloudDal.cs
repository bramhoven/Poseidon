using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using Ovh.Api;
using Poseidon.DataLayer.Cloud.Models.Ovh;
using Poseidon.DataLayer.Mappers;
using Poseidon.Helpers.Settings;
using Poseidon.Models.Cloud;
using Poseidon.Models.Cloud.Ovh;
using Poseidon.Models.Servers;

namespace Poseidon.DataLayer.Cloud
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
        ///     Initializes a new instance of <see cref="OvhCloudDal" />.
        /// </summary>
        public OvhCloudDal()
        {
            if (string.IsNullOrWhiteSpace(SettingsHelper.OvhApplicationKey))
                throw new ArgumentException("The ApplicationKey is not set in the configurations.",
                    nameof(SettingsHelper.OvhApplicationKey));

            if (string.IsNullOrWhiteSpace(SettingsHelper.OvhApplicationSecret))
                throw new ArgumentException("The ApplicationSecret is not set in the configurations.",
                    nameof(SettingsHelper.OvhApplicationSecret));

            if (string.IsNullOrWhiteSpace(SettingsHelper.OvhCustomerKey))
                throw new ArgumentException("The CustomerKey is not set in the configurations.",
                    nameof(SettingsHelper.OvhCustomerKey));

            _client = new Client("ovh-eu", SettingsHelper.OvhApplicationKey, SettingsHelper.OvhApplicationSecret,
                SettingsHelper.OvhCustomerKey);
        }

        #endregion

        #region Methods

        public Server CreateServer(string name, string size, string image, string region)
        {
            if (string.IsNullOrWhiteSpace(SettingsHelper.OvhProject))
                throw new ArgumentException(nameof(SettingsHelper.OvhProject));

            var url = $"/cloud/project/{SettingsHelper.OvhProject}/instance";
            var requestData = new OvhInstanceCreationRequestData
            {
                FlavorId = size,
                Name = name,
                ImageId = image,
                Region = region,
                MonthlyBilling = true
            };

            try
            {
                var ovhServer = _client.PostAsync<OvhServer>(url, requestData).Result;
                var server = new Server
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
                var result = _client.GetAsync<ICollection<OvhImage>>(url).Result;
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
                var result = _client.GetAsync<ICollection<OvhFlavor>>(url).Result;
                return result.Select(flavor => new OvhInstanceSize(flavor)).Cast<InstanceSizeBase>().ToList();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return new List<InstanceSizeBase>();
            }
        }

        public ICollection<Region> getRegions()
        {
            var url = $"/cloud/project/{SettingsHelper.OvhProject}/region";

            try
            {
                var result = _client.GetAsync<ICollection<string>>(url).Result;
                return result.Select(region => new Region(region)).ToList();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return new List<Region>();
            }
        }

        public Server GetServer(string serverId)
        {
            var url = $"/cloud/project/{SettingsHelper.OvhProject}/instance/{serverId}";

            try
            {
                var server = _client.GetAsync<OvhServer>(url).Result;
                return OvhMapper.MapOvhServerToServer(server);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return null;
            }
        }

        public Server UpdateServer(Server server)
        {
            var url = $"/cloud/project/{SettingsHelper.OvhProject}/instance/{server.CloudId}";

            try
            {
                var updatedServer = _client.PutAsync<OvhServer>(url, new {instanceName = server.Name}).Result;
                return OvhMapper.MapOvhServerToServer(updatedServer);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return null;
            }
        }

        #endregion
    }
}