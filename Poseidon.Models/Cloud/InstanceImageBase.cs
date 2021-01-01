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
        public string Description { get; internal set; }

        /// <summary>
        ///     The id of this image.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        ///     The name of this image.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        ///     The os of this image.
        /// </summary>
        public string Os { get; internal set; }

        /// <summary>
        ///     The regions in which this image can be used.
        /// </summary>
        public ICollection<string> Regions { get; internal set; }

        /// <summary>
        ///     The shortname for this image.
        /// </summary>
        public string Slug { get; internal set; }

        /// <summary>
        ///     The tags for this image.
        /// </summary>
        public ICollection<string> Tags { get; internal set; }

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