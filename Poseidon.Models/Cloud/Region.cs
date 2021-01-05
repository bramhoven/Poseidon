namespace Poseidon.Models.Cloud
{
    public class Region
    {
        #region Properties

        /// <summary>
        ///     The name of this region.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The short name of this region.
        /// </summary>
        public string Slug { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of <see cref="Region" />
        /// </summary>
        public Region()
        {
        }

        /// <summary>
        ///     Initializes a new instance of <see cref="Region" />
        /// </summary>
        /// <param name="name">The name of this region</param>
        public Region(string name)
        {
            Name = name;
            Slug = name;
        }

        #endregion
    }
}