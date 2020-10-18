using System;

namespace Sertar.Models.Cloud
{
    public class InstanceSizeBase : IInstanceSize
    {
        #region Properties

        /// <summary>
        ///     The amount of cpu's.
        /// </summary>
        public int Cpu { get; internal set; }

        /// <summary>
        ///     The amount of gpu's.
        /// </summary>
        public int Gpu { get; internal set; }

        /// <summary>
        ///     The id of the size.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        ///     The name of the size.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        ///     The amount of ram.
        /// </summary>
        public int Ram { get; internal set; }

        /// <summary>
        ///     The region where this size can be used.
        /// </summary>
        public string Region { get; internal set; }

        /// <summary>
        ///     The amount of storage.
        /// </summary>
        public int Storage { get; internal set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialize a new instance of <see cref="Sertar.Models.Cloud.InstanceSizeBase"/>
        /// </summary>
        protected InstanceSizeBase()
        {
        }

        #endregion

        #region Methods

        public virtual string GetSizeDefinition()
        {
            throw new NotImplementedException("This function has not been implemented.");
        }

        #endregion
    }
}