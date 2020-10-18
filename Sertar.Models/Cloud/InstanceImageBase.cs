using System;

namespace Sertar.Models.Cloud
{
    public class InstanceImageBase : IInstanceImage
    {
        #region Properties

        /// <summary>
        ///     The id of this image.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     The name of this image.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The region in which this image can be used.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        ///     The os type of this image.
        /// </summary>
        public string Type { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialize a new instance of <see cref="Sertar.Models.Cloud.InstanceImageBase" />
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