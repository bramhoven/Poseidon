using Poseidon.Models.QueryLanguage.Tokens;

namespace Poseidon.Models.QueryLanguage.Tokenizer
{
    public class TokenMatch
    {
        public TokenType TokenType { get; set; }
        public string Value { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public int Precedence { get; set; }
    }
}