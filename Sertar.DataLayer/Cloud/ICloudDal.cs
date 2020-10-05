namespace Sertar.DataLayer.Cloud
{
    public interface ICloudDal
    {
        #region Methods

        /// <summary>
        /// Create a server.
        /// </summary>
        /// <param name="name">The name of the server</param>
        /// <returns>Whether request was successful</returns>
        bool CreateServer(string name);

        #endregion
    }
}