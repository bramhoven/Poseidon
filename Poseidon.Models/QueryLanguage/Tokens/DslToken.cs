namespace Poseidon.Models.QueryLanguage.Tokens
{
    public class DslToken
    {
        #region Properties

        public TokenType TokenType { get; set; }
        public string Value { get; set; }

        #endregion

        #region Constructors

        public DslToken(TokenType tokenType)
        {
            TokenType = tokenType;
            Value = string.Empty;
        }

        public DslToken(TokenType tokenType, string value)
        {
            TokenType = tokenType;
            Value = value;
        }

        #endregion

        #region Methods

        public DslToken Clone()
        {
            return new DslToken(TokenType, Value);
        }

        #endregion
    }
}