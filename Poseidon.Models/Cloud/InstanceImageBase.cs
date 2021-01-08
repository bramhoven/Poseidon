using System;
using System.Collections.Generic;

namespace Poseidon.Models.Cloud
{
    public class InstanceImageBase : IInstanceImage
    {
        #region Properties

        /// <summary>
        ///     The description of this image.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     The id of this image.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     The name of this image.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The os of this image.
        /// </summary>
        public string Os { get; set; }

        /// <summary>
        ///     The regions in which this image can be used.
        /// </summary>
        public ICollection<string> Regions { get; set; }

        /// <summary>
        ///     The shortname for this image.
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        ///     The tags for this image.
        /// </summary>
        public ICollection<string> Tags { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialize a new instance of <see cref="InstanceImageBase" />
        /// </summary>
        protected InstanceImageBase()
        {
        }

        #endregion

        #region Methods

        public virtual string GetImageDefinition()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}