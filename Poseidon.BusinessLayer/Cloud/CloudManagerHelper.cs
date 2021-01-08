using System.Collections.Generic;
using System.Linq;
using Poseidon.DataLayer.Cloud;
using Poseidon.DataLayer.Contexts.ServerContext;
using Poseidon.Helpers.Settings;
using Poseidon.Models.Cloud;
using Poseidon.Models.Servers;

namespace Poseidon.BusinessLayer.Cloud
{
    public static class CloudManagerHelper
    {
        #region Methods

        #region Static Methods

        /// <summary>
        ///     Configures the cloud providers.
        /// </summary>
        public static void ConfigureCloudProviders(ICloudProviderDal cloudProviderDal)
        {
            var cloudProviders = new List<CloudProvider>();
            cloudProviders.AddRange(new[]
            {
                new CloudProvider
                {
                    CloudProviderType = CloudProviderType.Ovh,
                    Id = (int) CloudProviderType.Ovh,
                    Name = "Ovh",
                    Slug = "ovh"
                },
                new CloudProvider
                {
                    CloudProviderType = CloudProviderType.DigitalOcean,
                    Id = (int) CloudProviderType.DigitalOcean,
                    Name = "Digital Ocean",
                    Slug = "digitalocean"
                }
            });

            var dbProviders = cloudProviderDal.GetCloudProviders();
            var dbProviderIds = dbProviders.Select(dbProvider => dbProvider.Id);
            foreach (var cloudProvider in cloudProviders.Where(provider => dbProviderIds.Contains(provider.Id)))
            {
                var provider = cloudProviderDal.GetCloudProviderByType(cloudProvider.CloudProviderType);
                provider.Name = cloudProvider.Name;
                provider.Slug = cloudProvider.Slug;
                cloudProviderDal.UpdateCloudProvider(provider);
            }
                

            foreach (var cloudProvider in cloudProviders.Where(provider => !dbProviderIds.Contains(provider.Id)))
                cloudProviderDal.AddCloudProvider(cloudProvider);
        }

        /// <summary>
        ///     Get the correct cloud dal for server.
        /// </summary>
        /// <param name="server">The server</param>
        /// <returns></returns>
        public static ICloudDal GetDalForServer(Server server, DbServerContext serverContext)
        {
            if (server.CloudProvider == null)
                return null;

            switch (server.CloudProvider.CloudProviderType)
            {
                case CloudProviderType.Ovh:
                    return GetOvhDal();
                case CloudProviderType.DigitalOcean:
                    return GetDigitalOceanDal();
            }

            return null;
        }

        /// <summary>
        ///     Gets the correct digital ocean dal.
        /// </summary>
        /// <returns></returns>
        public static ICloudDal GetDigitalOceanDal()
        {
            return SettingsHelper.MockDigitalOcean
                ? (ICloudDal) new MockCloudDal(CloudProviderType.DigitalOcean)
                : new DigitalOceanCloudDal();
        }

        /// <summary>
        ///     Gets the correct ovh dal.
        /// </summary>
        /// <returns></returns>
        public static ICloudDal GetOvhDal()
        {
            return SettingsHelper.MockOvh ? (ICloudDal) new MockCloudDal(CloudProviderType.Ovh) : new OvhCloudDal();
        }

        #endregion

        #endregion
    }
}