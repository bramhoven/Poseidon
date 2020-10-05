using System;

namespace Sertar.Models.Cloud
{
    public class InstanceSizeBase : IInstanceSize
    {
        #region Fields

        /// <summary>
        ///     The amount of cpu's.
        /// </summary>
        public int Cpu;

        /// <summary>
        ///     The amount of gpu's.
        /// </summary>
        public int Gpu;

        /// <summary>
        ///     The amount of ram.
        /// </summary>
        public int Ram;

        /// <summary>
        ///     The amount of storage.
        /// </summary>
        public int Storage;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialize the InstanceSizeBase object.
        /// </summary>
        /// <param name="cpu">The amount of cpu's</param>
        /// <param name="ram">The amount of ram</param>
        /// <param name="storage">The amount of storage</param>
        public InstanceSizeBase(int cpu, int ram, int storage)
        {
            Cpu = cpu;
            Ram = ram;
            Storage = storage;
        }

        /// <summary>
        ///     Initialize the InstanceSizeBase object.
        /// </summary>
        /// <param name="cpu">The amount of cpu's</param>
        /// <param name="ram">The amount of ram</param>
        /// <param name="storage">The amount of storage</param>
        /// <param name="gpu">The amount of gpu's</param>
        public InstanceSizeBase(int cpu, int ram, int storage, int gpu) : this(cpu, ram, storage)
        {
            Gpu = gpu;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Get the size definition string for the specific cloud provider.
        /// </summary>
        /// <returns>The size definition string</returns>
        public string GetSizeDefinition()
        {
            throw new NotImplementedException("This function has not been implemented.");
        }

        #endregion
    }
}