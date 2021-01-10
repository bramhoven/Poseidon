using System.Collections.Generic;
using System.Linq;
using Poseidon.Models.QueryLanguage.DataRepresentation;
using Poseidon.Models.QueryLanguage.Tokenizer;

namespace Poseidon.BusinessLayer.QueryLanguage
{
    public class QueryLanguageManager
    {
        public DslQueryModel ParseQuery(string query)
        {
            var tokenizer = new Tokenizer();
            var tokenSequence = tokenizer.Tokenize(query).ToList();

            var parser = new Parser();
            return parser.Parse(tokenSequence);
        }
    }
}