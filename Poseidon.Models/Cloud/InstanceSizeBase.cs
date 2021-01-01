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
        ///     The regions where this size can be used.
        /// </summary>
        public ICollection<string> Regions { get; internal set; }

        /// <summary>
        ///     The shortname for this size.
        /// </summary>
        public string Slug { get; internal set; }

        /// <summary>
        ///     The amount of storage.
        /// </summary>
        public int Storage { get; internal set; }

        /// <summary>
        ///     The amount of network transfer.
        /// </summary>
        public double Transfer { get; internal set; }

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