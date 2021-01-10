using System.Collections.Generic;

namespace Poseidon.Models.QueryLanguage.DataRepresentation
{
    public class ComparisonCondition
    {
        public string DataItemName { get; set; }
        public DslOperator Operator { get; set; }
        public string Value { get; set; }

        public DslLogicalOperator LogOpToNextCondition { get; set; }
    }
}