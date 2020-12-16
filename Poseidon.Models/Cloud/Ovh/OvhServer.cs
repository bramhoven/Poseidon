using System;
using System.Collections.Generic;

namespace Poseidon.Models.Cloud.Ovh
{
    public class OvhServer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
        public string Region { get; set; }
        public OvhFlavor Flavor { get; set; }
        public OvhImage Image { get; set; }
        public string PlanCode { get; set; }
        public ICollection<OvhIpAddress> IpAddresses { get; set; }
    }
}