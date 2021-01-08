namespace Poseidon.Models.Cloud
{
    public class CloudProvider
    {
        #region Properties

        /// <summary>
        ///     The cloud provider type.
        /// </summary>
        public CloudProviderType CloudProviderType { get; set; }

        /// <summary>
        ///     The id of the cloud provider.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The name of the cloud provider.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The short name of the provider used in the api.
        /// </summary>
        public string Slug { get; set; }

        #endregion
    }
}