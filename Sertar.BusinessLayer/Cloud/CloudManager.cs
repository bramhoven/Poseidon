using Sertar.DataLayer.Cloud;

namespace Sertar.BusinessLayer.Cloud
{
    public class CloudManager
    {
        #region Fields

        /// <summary>
        ///     The cloud datalayer object.
        /// </summary>
        private readonly ICloudDal _cloudDal;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize the CloudManager.
        /// </summary>
        /// <param name="cloudDal">The cloud provider to use</param>
        public CloudManager(ICloudDal cloudDal)
        {
            _cloudDal = cloudDal;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Create a server.
        /// </summary>
        /// <param name="name">The name of the server</param>
        /// <returns></returns>
        public bool CreateServer(string name)
        {
            return _cloudDal.CreateServer(name);
        }

        #endregion
    }
}