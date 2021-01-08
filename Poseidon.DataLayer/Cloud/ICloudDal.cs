using System.Collections.Generic;
using Poseidon.Models.Cloud;
using Poseidon.Models.Security;
using Poseidon.Models.Servers;

namespace Poseidon.DataLayer.Cloud
{
    public interface ICloudDal
    {
        #region Methods

        /// <summary>
        ///     Configures the provider.
        /// </summary>
        /// <param name="cloudProviderDal">The server context</param>
        void ConfigureProvider(ICloudProviderDal cloudProviderDal);

        /// <summary>
        ///     Create a server.
        /// </summary>
        /// <param name="name">The name of the server</param>
        /// <param name="size">The size of the sever</param>
        /// <param name="image">The image of the server</param>
        /// <param name="region">The region where the server should be deployed</param>
        /// <param name="sshKeyId">The ssh key id</param>
        /// <returns>Whether request was successful</returns>
        Server CreateServer(string name, string size, string image, string region, string sshKeyId);

        /// <summary>
        ///     Delets a server based on it's cloud id.
        /// </summary>
        /// <param name="cloudId">The cloud id</param>
        /// <returns></returns>
        bool DeleteServer(string cloudId);

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
        ///     Get public ssh keys stored by cloud provider.
        /// </summary>
        /// <returns></returns>
        ICollection<PublicSshKey> GetSshKeys();

        /// <summary>
        ///     Updates the server.
        /// </summary>
        /// <param name="server">The new server data</param>
        /// <returns></returns>
        Server UpdateServer(Server server);

        #endregion
    }
}