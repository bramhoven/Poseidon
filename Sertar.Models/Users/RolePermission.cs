namespace Sertar.Models.Users
{
    public class RolePermission
    {
        #region Properties

        /// <summary>
        ///     The user right id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The permission.
        /// </summary>
        public Permissions Permission { get; set; }

        /// <summary>
        ///     The role.
        /// </summary>
        public Role role { get; set; }

        #endregion
    }
}