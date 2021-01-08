using System;
using System.Collections.Generic;

namespace Poseidon.Models.Cloud
{
    public class InstanceSizeBase : IInstanceSize
    {
        #region Properties

        /// <summary>
        ///     The amount of cpu's.
        /// </summary>
        public int Cpu { get; set; }

        /// <summary>
        ///     The amount of gpu's.
        /// </summary>
        public int Gpu { get; set; }

        /// <summary>
        ///     The id of the size.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     The name of the size.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The amount of ram.
        /// </summary>
        public int Ram { get; set; }

        /// <summary>
        ///     The regions where this size can be used.
        /// </summary>
        public ICollection<string> Regions { get; set; }

        /// <summary>
        ///     The short name for this size.
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        ///     The amount of storage.
        /// </summary>
        public int Storage { get; set; }

        /// <summary>
        ///     The amount of network transfer.
        /// </summary>
        public double Transfer { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialize a new instance of <see cref="InstanceSizeBase" />
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