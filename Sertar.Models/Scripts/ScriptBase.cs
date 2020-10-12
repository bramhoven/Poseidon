using System.Collections.Generic;

namespace Sertar.Models.Scripts
{
    public class ScriptBase
    {
        #region Fields

        /// <summary>
        ///     The name of this script.
        /// </summary>
        public string Name;

        /// <summary>
        ///     The steps this script has.
        /// </summary>
        public List<ScriptStep> Steps;

        #endregion
    }
}