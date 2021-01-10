using System.Collections.Generic;
using System.Linq;
using Poseidon.Exceptions.QueryLanguage;
using Poseidon.Models.QueryLanguage.DataRepresentation;
using Poseidon.Models.QueryLanguage.Tokens;

namespace Poseidon.BusinessLayer.QueryLanguage
{
    /// <summary>
    ///     Grammar:
    ///     --------
    ///     S -> COMPARISON_CONDITION
    ///     COMPARISON_CONDITION -> data_item_name equals int_value COMPARISON_CONDITION_NEXT
    ///     COMPARISON_CONDITION -> data_item_name not_equals int_value COMPARISON_CONDITION_NEXT
    ///     COMPARISON_CONDITION -> data_item_name greater_than int_value COMPARISON_CONDITION_NEXT
    ///     COMPARISON_CONDITION -> data_item_name greater_equals int_value COMPARISON_CONDITION_NEXT
    ///     COMPARISON_CONDITION -> data_item_name less_than int_value COMPARISON_CONDITION_NEXT
    ///     COMPARISON_CONDITION -> data_item_name less_equals int_value COMPARISON_CONDITION_NEXT
    ///     COMPARISON_CONDITION_NEXT -> and COMPARISON_CONDITION
    ///     COMPARISON_CONDITION_NEXT -> eos
    ///     --------
    /// </summary>

    public class Parser
    {
        #region Fields

        private const string ExpectedObjectErrorText = "Expected string value as data item name but found: ";
        private const string ExpectedOperationErrorText = "Expected ==, >, >=, <, <= but found: ";
        private const string ExpectedAndErrorText = "Expected AND but found: ";

        private ComparisonCondition _currentComparisonCondition;
        private DslToken _lookaheadFirst;
        private DslToken _lookaheadSecond;

        // IR class that we will build as we go
        private DslQueryModel _queryModel;

        // Stack and Lookaheads
        private Stack<DslToken> _tokenSequence;

        #endregion

        #region Methods

        public DslQueryModel Parse(List<DslToken> tokens)
        {
            // create the stack and load the lookaheads
            LoadSequenceStack(tokens);
            PrepareLookaheads();
            _queryModel = new DslQueryModel();

            // S -> CONDITION
            ComparisonCondition();

            DiscardToken(TokenType.SequenceTerminator);

            return _queryModel;
        }

        private void AndComparisonCondition()
        {
            _currentComparisonCondition.LogOpToNextCondition = DslLogicalOperator.And;
            DiscardToken(TokenType.And);
            ComparisonCondition();
        }

        private void ComparisonCondition()
        {
            CreateNewMatchCondition();

            if (IsObject(_lookaheadFirst))
            {
                if (IsEqualityOperator(_lookaheadSecond))
                {
                    EqualityMatchCondition();
                }
                else
                {
                    throw new DslParserException(ExpectedOperationErrorText + _lookaheadSecond.Value);
                }

                ComparisonConditionNext();
            }
            else
            {
                throw new DslParserException(ExpectedObjectErrorText + _lookaheadFirst.Value);
            }
        }

        private void ComparisonConditionNext()
        {
            if (_lookaheadFirst.TokenType == TokenType.And)
            {
                AndComparisonCondition();
            }
            else if (_lookaheadFirst.TokenType != TokenType.SequenceTerminator)
            {
                throw new DslParserException(ExpectedAndErrorText + _lookaheadFirst.Value);
            }
        }

        private void CreateNewMatchCondition()
        {
            // create a new empty ComparisonCondition instance ready to fill
            _currentComparisonCondition = new ComparisonCondition();
            _currentComparisonCondition.LogOpToNextCondition = DslLogicalOperator.None;
            _queryModel.ComparisonConditions.Add(_currentComparisonCondition);
        }

        private void DiscardToken()
        {
            _lookaheadFirst = _lookaheadSecond.Clone();

            if (_tokenSequence.Any())
                _lookaheadSecond = _tokenSequence.Pop();
            else
                _lookaheadSecond = new DslToken(TokenType.SequenceTerminator, string.Empty);
        }

        private void DiscardToken(TokenType tokenType)
        {
            if (_lookaheadFirst.TokenType != tokenType)
                throw new DslParserException(string.Format("Expected {0} but found: {1}",
                    tokenType.ToString().ToUpper(), _lookaheadFirst.Value));

            DiscardToken();
        }

        private void EqualityMatchCondition()
        {
            _currentComparisonCondition.DataItemName = _lookaheadFirst.Value;
            DiscardToken();
            _currentComparisonCondition.Operator = GetOperator(_lookaheadFirst);
            DiscardToken();
            _currentComparisonCondition.Value = _lookaheadFirst.Value;
            DiscardToken();
        }

        private DslOperator GetOperator(DslToken token)
        {
            switch (token.TokenType)
            {
                case TokenType.Equals:
                    return DslOperator.Equals;
                case TokenType.NotEquals:
                    return DslOperator.NotEquals;
                case TokenType.GreaterThan:
                    return DslOperator.GreaterThan;
                case TokenType.GreaterEquals:
                    return DslOperator.GreaterEquals;
                case TokenType.LessThan:
                    return DslOperator.LessThan;
                case TokenType.LessEquals:
                    return DslOperator.LessEquals;
                default:
                    throw new DslParserException(ExpectedOperationErrorText + token.Value);
            }
        }

        private bool IsEqualityOperator(DslToken token)
        {
            return token.TokenType == TokenType.Equals
                   || token.TokenType == TokenType.NotEquals
                   || token.TokenType == TokenType.GreaterThan
                   || token.TokenType == TokenType.GreaterEquals
                   || token.TokenType == TokenType.LessThan
                   || token.TokenType == TokenType.LessEquals;
        }

        private bool IsObject(DslToken token)
        {
            return token.TokenType == TokenType.DataItemName;
        }

        private void LoadSequenceStack(List<DslToken> tokens)
        {
            _tokenSequence = new Stack<DslToken>();
            int count = tokens.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                _tokenSequence.Push(tokens[i]);
            }
        }

        private void PrepareLookaheads()
        {
            _lookaheadFirst = _tokenSequence.Pop();
            _lookaheadSecond = _tokenSequence.Pop();
        }

        private DslToken ReadToken(TokenType tokenType)
        {
            if (_lookaheadFirst.TokenType != tokenType)
                throw new DslParserException(string.Format("Expected {0} but found: {1}",
                    tokenType.ToString().ToUpper(), _lookaheadFirst.Value));

            return _lookaheadFirst;
        }

        #endregion
    }
}