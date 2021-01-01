using Poseidon.DataLayer.Cloud;
using Poseidon.Helpers.Settings;

namespace Poseidon.BusinessLayer.Cloud
{
    public static class CloudManagerHelper
    {
        #region Methods

        #region Static Methods

        /// <summary>
        ///     Gets the correct ovh dal.
        /// </summary>
        /// <returns></returns>
        public static ICloudDal GetOvhDal()
        {
            return SettingsHelper.MockOvh ? (ICloudDal) new MockCloudDal() : new OvhCloudDal();
        }

        /// <summary>
        ///     Gets the correct digital ocean dal.
        /// </summary>
        /// <returns></returns>
        public static ICloudDal GetDigitalOceanDal()
        {
            return SettingsHelper.MockDigitalOcean ? (ICloudDal)new MockCloudDal() : new DigitalOceanCloudDal();
        }

        #endregion

        #endregion
    }
}