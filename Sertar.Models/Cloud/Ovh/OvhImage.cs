using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Sertar.Models.Cloud.Ovh
{
    public class OvhImage
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Visibility { get; set; }
        public string Type { get; set; }
        public int MinDisk { get; set; }
        public int MinRam { get; set; }
        public float Size { get; set; }
        public DateTime CreationDate { get; set; }
        public string Status { get; set; }
        public string User { get; set; }
        public string FlavorType { get; set; }
        public ICollection<string> Tags { get; set; }
        public string PlanCode { get; set; }
    }
}