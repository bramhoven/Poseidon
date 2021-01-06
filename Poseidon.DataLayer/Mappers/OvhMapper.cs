using System.Linq;
using Poseidon.Models.Cloud.Ovh;
using Poseidon.Models.Security;
using Poseidon.Models.Servers;

namespace Poseidon.DataLayer.Mappers
{
    public sealed class OvhMapper
    {
        #region Methods

        #region Static Methods

        /// <summary>
        ///     Map the ovh key to the public ssh key model.
        /// </summary>
        /// <param name="ovhKey">The ovh ssh key</param>
        /// <returns></returns>
        internal static PublicSshKey MapOvhKeyToPublicSshKey(OvhSshKey ovhKey)
        {
            return new PublicSshKey
            {
                Id = ovhKey.Id,
                Name = ovhKey.Name,
                PublicKey = ovhKey.PublicKey,
                Fingerprint = string.Empty
            };
        }

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

        #endregion

        #endregion
    }
}