namespace Sertar.Models.Cloud
{
    interface IInstanceSize
    {
        #region Methods

        /// <summary>
        ///     Get the size definition string for the specific cloud provider.
        /// </summary>
        /// <returns>The size definition string</returns>
        string GetSizeDefinition();

        #endregion
    }
}