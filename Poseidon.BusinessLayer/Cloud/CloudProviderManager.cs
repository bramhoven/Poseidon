using System.Collections.Generic;
using Poseidon.DataLayer.Cloud;
using Poseidon.Models.Cloud;

namespace Poseidon.BusinessLayer.Cloud
{
    public class CloudProviderManager
    {
        #region Fields

        /// <summary>
        ///     The cloud provider dal.
        /// </summary>
        private readonly ICloudProviderDal _cloudProviderDal;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new intance of <see cref="CloudProviderManager" />
        /// </summary>
        /// <param name="cloudProviderDal"></param>
        public CloudProviderManager(ICloudProviderDal cloudProviderDal)
        {
            _cloudProviderDal = cloudProviderDal;
        }

        #endregion

        #region Methods
        /// <summary>
        ///     Get cloud provider by id.
        /// </summary>
        /// <param name="cloudProviderId">The cloud provider id</param>
        /// <returns></returns>
        public CloudProvider GetCloudProvider(int cloudProviderId)
        {
            return _cloudProviderDal.GetCloudProvider(cloudProviderId);
        }

        /// <summary>
        ///     Get cloud provider by type.
        /// </summary>
        /// <param name="cloudProviderType">The cloud provider type</param>
        /// <returns></returns>
        public CloudProvider GetCloudProviderByType(CloudProviderType cloudProviderType)
        {
            return _cloudProviderDal.GetCloudProviderByType(cloudProviderType);
        }

        /// <summary>
        ///     Get all cloud providers.
        /// </summary>
        /// <returns></returns>
        public ICollection<CloudProvider> GetCloudProviders()
        {
            return _cloudProviderDal.GetCloudProviders();
        }

        #endregion
    }
}