using System.Collections.Generic;

namespace Sertar.BusinessLayer.Scripts
{
    public class ScriptStepBase
    {
        #region Fields

        public List<string> Commands;
        public string Name { get; set; }

        #endregion
    }
}