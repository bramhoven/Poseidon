namespace Poseidon.DataLayer.Cloud.Models.Ovh
{
    public class OvhInstanceCreationRequestData
    {
        #region Properties

        public string FlavorId { get; set; }
        public string ImageId { get; set; }
        public bool MonthlyBilling { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string SshKeyId { get; set; }

        #endregion
    }
}