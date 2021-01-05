using System.Collections.Generic;
using Poseidon.Models.Cloud;
using Poseidon.Models.Servers;

namespace Poseidon.DataLayer.Cloud
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
        Server CreateServer(string name, string size, string image, string region);

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

        /// <summary>
        ///     Gets all the regions from the cloud provider.
        /// </summary>
        /// <returns></returns>
        ICollection<Region> getRegions();

        /// <summary>
        ///     Gets a server from the cloud provider.
        /// </summary>
        /// <param name="serverId">The cloud server id</param>
        /// <returns></returns>
        Server GetServer(string serverId);

        /// <summary>
        ///     Updates the server.
        /// </summary>
        /// <param name="server">The new server data</param>
        /// <returns></returns>
        Server UpdateServer(Server server);

        #endregion
    }
}