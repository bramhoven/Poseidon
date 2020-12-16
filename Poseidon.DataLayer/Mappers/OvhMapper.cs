using System;
using System.Linq;
using Poseidon.Models.Cloud.Ovh;
using Poseidon.Models.Servers;

namespace Poseidon.DataLayer.Mappers
{
    public sealed class OvhMapper
    {
        internal static Server MapOvhServerToServer(OvhServer ovhServer)
        {
            return new Server
            {
                CloudId = ovhServer.Id,
                InstallationScript = null,
                InstallationScriptLocation = null,
                IpAddresses = ovhServer.IpAddresses.Select(ip => new IpAddress
                {
                    Ip = ip.Ip,
                    Name = string.Empty,
                    Version = (int) ip.Version
                }).ToList(),
                MainIpAddress = ovhServer.IpAddresses.FirstOrDefault(ip => ip.Version == 4)?.Ip,
                Name = ovhServer.Name
            };
        }
    }
}