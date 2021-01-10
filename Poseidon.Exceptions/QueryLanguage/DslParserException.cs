using System;

namespace Poseidon.Exceptions.QueryLanguage
{
    [Serializable]
    public class DslParserException : Exception
    {
        public DslParserException() : base() { }
        public DslParserException(string message) : base(message) { }
        public DslParserException(string message, Exception inner) : base(message, inner) { }
    }
}