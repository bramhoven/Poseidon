using DigitalOcean.API.Models.Responses;

namespace Poseidon.Models.Cloud
{
    public class DigitalOceanInstanceSize : InstanceSizeBase
    {
        #region Properties

        /// <summary>
        ///     The price per hour
        /// </summary>
        public decimal PriceHourly { get; internal set; }

        /// <summary>
        ///     The price per month.
        /// </summary>
        public decimal PriceMonthly { get; internal set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of <see cref="DigitalOceanInstanceSize" />
        /// </summary>
        public DigitalOceanInstanceSize(Size digitalOceanSize)
        {
            PriceHourly = digitalOceanSize.PriceHourly;
            PriceMonthly = digitalOceanSize.PriceMonthly;
            Regions = digitalOceanSize.Regions;
            Cpu = digitalOceanSize.Vcpus;
            Ram = digitalOceanSize.Memory;
            Storage = digitalOceanSize.Disk;
            Name = digitalOceanSize.Slug;
            Slug = digitalOceanSize.Slug;
            Transfer = digitalOceanSize.Transfer;
        }

        #endregion

        public override string GetSizeDefinition()
        {
            return Slug;
        }
    }
}