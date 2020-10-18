using System.Collections.Generic;
using System.Linq;
using Sertar.DataLayer.Cloud;
using Sertar.Models.Cloud;

namespace Sertar.BusinessLayer.Cloud
{
    public class CloudManager
    {
        #region Fields

        /// <summary>
        ///     The cloud datalayer object.
        /// </summary>
        private readonly ICloudDal _cloudDal;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialize the CloudManager.
        /// </summary>
        /// <param name="cloudDal">The cloud provider to use</param>
        public CloudManager(ICloudDal cloudDal)
        {
            _cloudDal = cloudDal;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Create a server.
        /// </summary>
        /// <param name="name">The name of the server</param>
        /// <param name="size">The size of the sever</param>
        /// <param name="region">The region where the server should be deployed</param>
        /// <returns>Whether request was successful</returns>
        public bool CreateServer(string name, string size, string image, string region)
        {
            return _cloudDal.CreateServer(name, size, image, region);
        }

        /// <summary>
        ///     Get available sizes for cloud provider.
        /// </summary>
        /// <returns>The sizes</returns>
        public ICollection<InstanceSizeBase> GetAvailableSizes()
        {
            return _cloudDal.GetAvailableSizes();
        }

        /// <summary>
        ///     Get available sizes for cloud provider by region.
        /// </summary>
        /// <param name="region">The region to filter by</param>
        /// <returns>The sizes</returns>
        public ICollection<InstanceSizeBase> GetAvailableSizes(string region)
        {
            return _cloudDal.GetAvailableSizes().Where(size => size.Region.ToLower().Equals(region.ToLower())).ToList();
        }

        /// <summary>
        ///     Get all available sizes for provider.
        /// </summary>
        /// <returns></returns>
        public ICollection<InstanceImageBase> GetAvailableImages()
        {
            return _cloudDal.GetAvailableImages();
        }

        /// <summary>
        ///     Get all available sizes for provider by region.
        /// </summary>
        /// <param name="region">The region to filter by</param>
        /// <returns></returns>
        public ICollection<InstanceImageBase> GetAvailableImages(string region)
        {
            return _cloudDal.GetAvailableImages().Where(image => image.Region.ToLower().Equals(region.ToLower())).ToList();
        }

        #endregion
    }
}