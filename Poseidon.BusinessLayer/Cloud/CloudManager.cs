using System.Collections.Generic;
using System.Linq;
using Poseidon.DataLayer.Cloud;
using Poseidon.Models.Cloud;
using Poseidon.Models.Security;
using Poseidon.Models.Servers;

namespace Poseidon.BusinessLayer.Cloud
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
        /// <param name="sshKeyId">The id of the ssh key to use with this server</param>
        /// <returns>The server</returns>
        public Server CreateServer(string name, string size, string image, string region, string sshKeyId)
        {
            return _cloudDal.CreateServer(name, size, image, region, sshKeyId);
        }

        /// <summary>
        ///     Delets a server based on cloud id.
        /// </summary>
        /// <param name="cloudId">The cloud id</param>
        /// <returns></returns>
        public bool DeleteServer(string cloudId)
        {
            return _cloudDal.DeleteServer(cloudId);
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
            return _cloudDal.GetAvailableImages().Where(image => image.Regions.Contains(region))
                .ToList();
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
            return _cloudDal.GetAvailableSizes().Where(size => size.Regions.Contains(region)).ToList();
        }


        /// <summary>
        ///     Gets the regions
        /// </summary>
        /// <returns></returns>
        public object GetRegions()
        {
            return _cloudDal.getRegions();
        }

        /// <summary>
        ///     Gets a server from cloud provider.
        /// </summary>
        /// <param name="serverId">The cloud server id</param>
        /// <returns></returns>
        public Server GetServer(string serverId)
        {
            return _cloudDal.GetServer(serverId);
        }

        /// <summary>
        ///     Gets the public ssh keys from the provider.
        /// </summary>
        /// <returns></returns>
        public ICollection<PublicSshKey> GetSshKeys()
        {
            return _cloudDal.GetSshKeys();
        }

        /// <summary>
        ///     Updates a server.
        /// </summary>
        /// <param name="server">The server to update</param>
        /// <returns></returns>
        public Server UpdateServer(Server server)
        {
            return _cloudDal.UpdateServer(server);
        }

        #endregion
    }
}