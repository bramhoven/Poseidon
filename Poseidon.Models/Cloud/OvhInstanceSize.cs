﻿using System;
using System.Collections.Generic;
using Poseidon.Models.Cloud.Ovh;

namespace Poseidon.Models.Cloud
{
    public class OvhInstanceSize : InstanceSizeBase
    {
        #region Properties

        /// <summary>
        ///     The ovh flavor to use for sizing.
        /// </summary>
        public OvhFlavor Flavor { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Instantiate a new instance of <see cref="OvhInstanceSize" />
        /// </summary>
        /// <param name="flavor">The ovh flavor to use for size</param>
        public OvhInstanceSize(OvhFlavor flavor)
        {
            Flavor = flavor;

            Id = flavor.Id;
            Name = flavor.Name;
            Regions = new List<string> { flavor.Region };
            Cpu = flavor.Vcpus;
            Ram = (int) Math.Floor(flavor.Ram * 1.024);
            Storage = flavor.Disk;
        }

        #endregion

        #region Methods

        public override string GetSizeDefinition()
        {
            return Flavor.Id;
        }

        #endregion
    }
}