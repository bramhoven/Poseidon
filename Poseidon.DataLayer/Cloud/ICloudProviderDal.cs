using System.Collections.Generic;
using Poseidon.Models.Cloud;

namespace Poseidon.DataLayer.Cloud
{
    public interface ICloudProviderDal
    {
        #region Methods

        /// <summary>
        ///     Add cloud provider.
        /// </summary>
        /// <param name="cloudProvider">The cloud provider to add</param>
        void AddCloudProvider(CloudProvider cloudProvider);

        /// <summary>
        ///     Get cloud provider by id.
        /// </summary>
        /// <param name="cloudProviderId">The cloud provider id</param>
        /// <returns></returns>
        CloudProvider GetCloudProvider(int cloudProviderId);

        /// <summary>
        ///     Get cloud provider by type.
        /// </summary>
        /// <param name="cloudProviderType">The cloud provider type</param>
        /// <returns></returns>
        CloudProvider GetCloudProviderByType(CloudProviderType cloudProviderType);

        /// <summary>
        ///     Get all cloud providers.
        /// </summary>
        /// <returns></returns>
        ICollection<CloudProvider> GetCloudProviders();

        /// <summary>
        ///     Updates a cloud provider.
        /// </summary>
        /// <param name="cloudProvider">The cloud provider to update</param>
        void UpdateCloudProvider(CloudProvider cloudProvider);

        #endregion
    }
}