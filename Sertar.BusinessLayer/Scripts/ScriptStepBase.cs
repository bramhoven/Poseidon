using System.Collections.Generic;

namespace Sertar.BusinessLayer.Scripts
{
    public class ScriptStepBase
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