using Poseidon.Models.Cloud.Ovh;

namespace Poseidon.Models.Cloud
{
    public class OvhInstanceImage : InstanceImageBase
    {
        #region Properties

        /// <summary>
        ///     The ovh image to use for image definition.
        /// </summary>
        public OvhImage Image { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of <see cref="OvhInstanceImage" />
        /// </summary>
        /// <param name="image"></param>
        public OvhInstanceImage(OvhImage image)
        {
            Image = image;

            Id = image.Id;
            Name = image.Name;
            Region = image.Region;
            Type = image.Type;
        }

        #endregion

        #region Methods

        public override string GetImageDefinition()
        {
            return Id;
        }

        #endregion
    }
}