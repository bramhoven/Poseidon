using System;
using System.Collections;
using System.Collections.Generic;

namespace Poseidon.Models.Cloud.Ovh
{
    public class OvhFlavor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public int Ram { get; set; }
        public int Disk { get; set; }
        public int Vcpus { get; set; }
        public string Type { get; set; }
        public string OsType { get; set; }
        public int InboundBandwidth { get; set; }
        public int OutboundBandwidth { get; set; }
        public bool Available { get; set; }
        public IDictionary<string, string> PlanCodes { get; set; }
        public ICollection<FlavorCapabilities> Capabilities { get; set; }
        public int Quota { get; set; }
    }

    public class FlavorCapabilities
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
}