using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NLog;
using Poseidon.DataLayer.Contexts.ServerContext;
using Poseidon.Models.Cloud;

namespace Poseidon.DataLayer.Cloud
{
    public class CloudProviderDal : ICloudProviderDal
    {
        #region Fields

        /// <summary>
        ///     The logger.
        /// </summary>
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     The server context.
        /// </summary>
        private readonly DbServerContext _serverContext;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of <see cref="CloudProviderDal" />
        /// </summary>
        /// <param name="serverContext">The server context</param>
        public CloudProviderDal(DbServerContext serverContext)
        {
            _serverContext = serverContext;
        }

        #endregion

        #region Methods

        public void AddCloudProvider(CloudProvider cloudProvider)
        {
            _serverContext.CloudProviders.Add(cloudProvider);
            _serverContext.SaveChanges();
        }

        public CloudProvider GetCloudProvider(int cloudProviderId)
        {
            return _serverContext.CloudProviders.FirstOrDefault(provider => provider.Id == cloudProviderId);
        }

        public CloudProvider GetCloudProviderByType(CloudProviderType cloudProviderType)
        {
            return _serverContext.CloudProviders.FirstOrDefault(provider =>
                provider.CloudProviderType == cloudProviderType);
        }

        public ICollection<CloudProvider> GetCloudProviders()
        {
            return _serverContext.CloudProviders.ToList();
        }

        public void UpdateCloudProvider(CloudProvider cloudProvider)
        {
            _serverContext.CloudProviders.Attach(cloudProvider);
            _serverContext.Entry(cloudProvider).State = EntityState.Modified;
            _serverContext.SaveChanges();
        }

        #endregion
    }
}