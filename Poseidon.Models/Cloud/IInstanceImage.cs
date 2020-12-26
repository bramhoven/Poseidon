namespace Poseidon.Models.Cloud
{
    public interface IInstanceImage
    {
        /// <summary>
        ///     Get the size definition string for the specific cloud provider. This will be used in the call for server creation.
        /// </summary>
        /// <returns>The size definition string</returns>
        string GetImageDefinition();
    }
}