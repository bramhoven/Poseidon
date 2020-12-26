using System.Collections.Generic;

namespace Poseidon.Models.Users
{
    public class Role
    {
        #region Properties

        /// <summary>
        ///     The Id of this role.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The name of this role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The permissions that this role has.
        /// </summary>
        public List<RolePermission> Permissions { get; set; }

        #endregion
    }
}