namespace Poseidon.Models.Cloud
{
    public interface IInstanceSize
    {
        #region Methods

        /// <summary>
        ///     Get the size definition string for the specific cloud provider. This will be used in the call for server creation.
        /// </summary>
        /// <returns>The size definition string</returns>
        string GetSizeDefinition();

        #endregion
    }
}