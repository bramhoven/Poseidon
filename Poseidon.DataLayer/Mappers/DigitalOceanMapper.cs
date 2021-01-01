using System.Linq;
using DigitalOcean.API.Models.Responses;
using Poseidon.Models.Cloud;
using Poseidon.Models.Servers;

namespace Poseidon.DataLayer.Mappers
{
    public sealed class DigitalOceanMapper
    {
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

            return new Server()
            {
                CloudId = droplet.Id.ToString(),
                InstallationScript = null,
                InstallationScriptLocation = null,
                IpAddresses = ipv4.Union(ipv6).ToList(),
                MainIpAddress = droplet.Networks.V4.FirstOrDefault()?.IpAddress,
                Name = droplet.Name
            };
        }
    }
}