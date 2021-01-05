using System.Linq;
using DigitalOcean.API.Models.Responses;
using Poseidon.Models.Servers;
using Region = Poseidon.Models.Cloud.Region;

namespace Poseidon.DataLayer.Mappers
{
    public sealed class DigitalOceanMapper
    {
        #region Methods

        #region Static Methods

        /// <summary>
        ///     Maps the digital ocean region to the region model.
        /// </summary>
        /// <param name="doRegion">The digital ocean region</param>
        /// <returns></returns>
        public static Region MapDigitalOceanRegionToRegion(DigitalOcean.API.Models.Responses.Region doRegion)
        {
            return new Region
            {
                Name = doRegion.Name,
                Slug = doRegion.Slug
            };
        }

        /// <summary>
        ///     Maps the digital ocean droplet to the server model.
        /// </summary>
        /// <param name="droplet">The digital ocean droplet</param>
        /// <returns></returns>
        internal static Server MapDropletToServer(Droplet droplet)
        {
            var ipv4 = droplet.Networks.V4.Select(ip => new IpAddress
            {
                Ip = ip.IpAddress,
                Name = string.Empty,
                Version = 4,
                Netmask = ip.Netmask,
                Gateway = ip.Gateway
            }).ToList();

            var ipv6 = droplet.Networks.V6.Select(ip => new IpAddress
            {
                Ip = ip.IpAddress,
                Name = string.Empty,
                Version = 6,
                Netmask = ip.Netmask.ToString(),
                Gateway = ip.Gateway
            }).ToList();

            return new Server
            {
                CloudId = droplet.Id.ToString(),
                InstallationScript = null,
                InstallationScriptLocation = null,
                IpAddresses = ipv4.Union(ipv6).ToList(),
                MainIpAddress = droplet.Networks.V4.FirstOrDefault()?.IpAddress,
                Name = droplet.Name
            };
        }

        #endregion

        #endregion
    }
}