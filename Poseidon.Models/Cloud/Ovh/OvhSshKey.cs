using System.Collections.Generic;

namespace Poseidon.Models.Cloud.Ovh
{
    public class OvhSshKey
    {
        #region Properties

        public string Id { get; set; }
        public string Name { get; set; }
        public string PublicKey { get; set; }
        public ICollection<string> Regions { get; set; }

        #endregion
    }
}