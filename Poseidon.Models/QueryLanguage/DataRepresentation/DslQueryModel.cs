using System.Collections.Generic;

namespace Poseidon.Models.QueryLanguage.DataRepresentation
{
    public class DslQueryModel
    {
        #region Properties

        public IList<ComparisonCondition> ComparisonConditions { get; set; }

        #endregion

        #region Constructors

        public DslQueryModel()
        {
            ComparisonConditions = new List<ComparisonCondition>();
        }

        #endregion
    }
}