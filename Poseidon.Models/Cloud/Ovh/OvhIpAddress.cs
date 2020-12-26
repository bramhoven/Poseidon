namespace Poseidon.Models.Cloud.Ovh
{
    public class OvhIpAddress
    {
        #region Properties

        public string GatewayIp { get; set; }
        public string Ip { get; set; }
        public string NetworkId { get; set; }
        public string Type { get; set; }
        public long Version { get; set; }

        #endregion
    }
}