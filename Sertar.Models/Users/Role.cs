using System.Collections.Generic;

namespace Sertar.BusinessLayer.Users
{
    public class Role
    {
        #region Fields

        /// <summary>
        ///     The name of this role.
        /// </summary>
        public string Name;

        /// <summary>
        ///     The permissions that this role has.
        /// </summary>
        public List<Permissions> Permissions;

        #endregion
    }
}