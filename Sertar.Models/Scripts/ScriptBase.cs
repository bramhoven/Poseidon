using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sertar.Models.Scripts
{
    public class ScriptBase
    {
        #region Fields

        /// <summary>
        /// Id of the ScriptBase.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     The name of this script.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The steps this script has.
        /// </summary>
        [NotMapped]
        public List<ScriptStep> Steps { get; set; }

        #endregion
    }
}