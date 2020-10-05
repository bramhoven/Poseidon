using System;
using System.Collections.Generic;
using System.Text;

namespace Sertar.Models.Scripts
{
    public class ScriptStep
    {
        #region Fields

        /// <summary>
        /// The commands that will be executed in this step.
        /// </summary>
        public List<string> Commands;

        /// <summary>
        /// The name of this step.
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}
