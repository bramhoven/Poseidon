using System.Collections.Generic;
using Sertar.Models.Cloud;

namespace Sertar.DataLayer.Cloud
{
    public interface ICloudDal
    {
        #region Methods

        /// <summary>
        ///     Create a server.
        /// </summary>
        /// <param name="name">The name of the server</param>
        /// <param name="size">The size of the sever</param>
        /// <param name="image">The image of the server</param>
        /// <param name="region">The region where the server should be deployed</param>
        /// <returns>Whether request was successful</returns>
        bool CreateServer(string name, string size, string image, string region);

        /// <summary>
        ///     Get all available images for provider.
        /// </summary>
        /// <returns></returns>
        ICollection<InstanceImageBase> GetAvailableImages();

        /// <summary>
        ///     Get all available sizes for provider.
        /// </summary>
        /// <returns></returns>
        ICollection<InstanceSizeBase> GetAvailableSizes();

        #endregion
    }
}