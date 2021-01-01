using DigitalOcean.API.Models.Responses;

namespace Poseidon.Models.Cloud
{
    public class DigitalOceanInstanceImage : InstanceImageBase
    {
        #region Properties

        /// <summary>
        ///     The size of this image.
        /// </summary>
        public double ImageSize { get; internal set; }

        /// <summary>
        ///     The minimum disk size to use with this image.
        /// </summary>
        public int MinimumDiskSize { get; internal set; }

        #endregion

        #region Constructors

        public DigitalOceanInstanceImage(Image digitalOceanImage)
        {
            Id = digitalOceanImage.Id.ToString();
            Slug = digitalOceanImage.Slug;
            Name = digitalOceanImage.Name;
            Regions = digitalOceanImage.Regions;
            MinimumDiskSize = digitalOceanImage.MinDiskSize;
            ImageSize = digitalOceanImage.SizeGigabytes;
            Tags = digitalOceanImage.Tags;
            Os = digitalOceanImage.Distribution;
            Description = digitalOceanImage.Description;
        }

        #endregion
    }
}