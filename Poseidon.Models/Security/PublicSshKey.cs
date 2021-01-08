using Poseidon.Models.Cloud;

namespace Poseidon.Models.Security
{
    public class PublicSshKey
    {
        #region Properties

        public string Fingerprint { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string PublicKey { get; set; }
        public CloudProvider Provider { get; set; }

        #endregion
    }
}