using System;
using System.Collections.Generic;
using System.Linq;
using DigitalOcean.API;
using DigitalOcean.API.Models.Requests;
using NLog;
using Poseidon.DataLayer.Mappers;
using Poseidon.Helpers.Settings;
using Poseidon.Models.Cloud;
using Poseidon.Models.Security;
using Poseidon.Models.Servers;

namespace Poseidon.DataLayer.Cloud
{
    public class DigitalOceanCloudDal : ICloudDal
    {
        #region Fields

        /// <summary>
        ///     The cloud provider.
        /// </summary>
        private static CloudProvider _cloudProvider;

        /// <summary>
        ///     The digital ocean client.
        /// </summary>
        private readonly DigitalOceanClient _client;

        /// <summary>
        ///     The logger.
        /// </summary>
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors

        public DigitalOceanCloudDal()
        {
            if (string.IsNullOrWhiteSpace(SettingsHelper.DigitalOceanApiKey))
                throw new ArgumentException("The digital ocean api key is not set in the configurations.",
                    nameof(SettingsHelper.DigitalOceanApiKey));

            _client = new DigitalOceanClient(SettingsHelper.DigitalOceanApiKey);
        }

        #endregion

        #region Methods

        public void ConfigureProvider(ICloudProviderDal cloudProviderDal)
        {
            _cloudProvider = cloudProviderDal.GetCloudProviderByType(CloudProviderType.DigitalOcean);
        }

        public Server CreateServer(string name, string size, string image, string region, string sshKeyId)
        {
            try
            {
                var droplet = new Droplet
                {
                    Image = image,
                    Name = name,
                    Region = region,
                    Size = size,
                    SshKeys = new List<object> {sshKeyId}
                };
                var createdDroplet = _client.Droplets.Create(droplet).Result;
                var server = DigitalOceanMapper.MapDropletToServer(createdDroplet);
                server.CloudProvider = _cloudProvider;
                return server;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return null;
            }
        }

        public bool DeleteServer(string cloudId)
        {
            try
            {
                var result = _client.Droplets.Delete(long.Parse(cloudId));
                return result.IsCompleted && !result.IsCanceled && !result.IsFaulted;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return false;
            }
        }

        public ICollection<InstanceImageBase> GetAvailableImages()
        {
            try
            {
                var images = _client.Images.GetAll().Result;
                return images.Select(image => new DigitalOceanInstanceImage(image)).Cast<InstanceImageBase>().ToList();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return new List<InstanceImageBase>();
            }
        }

        public ICollection<InstanceSizeBase> GetAvailableSizes()
        {
            try
            {
                var sizes = _client.Sizes.GetAll().Result;
                return sizes.Select(size => new DigitalOceanInstanceSize(size)).Cast<InstanceSizeBase>().ToList();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return new List<InstanceSizeBase>();
            }
        }

        public ICollection<Region> getRegions()
        {
            try
            {
                var regions = _client.Regions.GetAll().Result;
                return regions.Select(DigitalOceanMapper.MapDigitalOceanRegionToRegion).ToList();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return new List<Region>();
            }
        }

        public Server GetServer(string serverId)
        {
            try
            {
                var droplet = _client.Droplets.Get(long.Parse(serverId)).Result;
                var server = DigitalOceanMapper.MapDropletToServer(droplet);
                server.CloudProvider = _cloudProvider;
                return server;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return null;
            }
        }

        public ICollection<PublicSshKey> GetSshKeys()
        {
            try
            {
                var sshKeys = _client.Keys.GetAll().Result;
                return sshKeys.Select(DigitalOceanMapper.MapKeyToPublicSshKey).ToList();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return new List<PublicSshKey>();
            }
        }

        public Server UpdateServer(Server server)
        {
            try
            {
                _client.DropletActions.Rename(long.Parse(server.CloudId), server.Name);
                return server;
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