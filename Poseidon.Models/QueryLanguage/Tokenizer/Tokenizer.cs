using System.Collections.Generic;
using System.Linq;
using Poseidon.Models.QueryLanguage.DataRepresentation;
using Poseidon.Models.QueryLanguage.Tokens;

namespace Poseidon.Models.QueryLanguage.Tokenizer
{
    public class Tokenizer
    {
        #region Fields

        private readonly ICollection<TokenDefinition> _tokenDefinitions;

        #endregion

        #region Constructors

        public Tokenizer()
        {
            _tokenDefinitions = new List<TokenDefinition>();

            _tokenDefinitions.Add(new TokenDefinition(TokenType.DataItemName, "([a-zA-Z]+)", 2));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.FloatValue, @"(\d+\.?\d*)", 1));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.Equals, "==", 1));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.NotEquals, "!=", 1));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.GreaterThan, ">", 2));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.GreaterEquals, ">=", 1));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.LessThan, "<", 2));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.LessEquals, "<=", 1));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.And, "and", 1));
        }

        #endregion

        #region Methods

        public IEnumerable<DslToken> Tokenize(string pqlText)
        {
            var tokenMatches = FindTokenMatches(pqlText);

            var groupedByIndex = tokenMatches.GroupBy(x => x.StartIndex)
                .OrderBy(x => x.Key)
                .ToList();

            TokenMatch lastMatch = null;
            for (int i = 0; i < groupedByIndex.Count; i++)
            {
                var bestMatch = groupedByIndex[i].OrderBy(x => x.Precedence).First();
                if (lastMatch != null && bestMatch.StartIndex < lastMatch.EndIndex)
                    continue;

                yield return new DslToken(bestMatch.TokenType, bestMatch.Value);

                lastMatch = bestMatch;
            }

            yield return new DslToken(TokenType.SequenceTerminator);
        }

        private List<TokenMatch> FindTokenMatches(string pqlText)
        {
            var tokenMatches = new List<TokenMatch>();

            foreach (var tokenDefinition in _tokenDefinitions)
                tokenMatches.AddRange(tokenDefinition.FindMatches(pqlText).ToList());

            return tokenMatches;
        }

        #endregion
    }
}