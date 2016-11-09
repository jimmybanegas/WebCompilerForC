using System;
using Lexer;

namespace Syntax
{
    public class Expressions
    {
        private readonly Parser _parser;

        public Expressions(Parser parser)
        {
            _parser = parser;
        }

        public void Expression()
        {
            RelationalExpression();
        }

        private void RelationalExpression()
        {
            ExpressionAddition();
            RelationalExpressionPrime();
        }

        private void RelationalExpressionPrime()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.OpLessThan)
                ||_parser.Utilities.CompareTokenType(TokenType.OpLessThanOrEqualTo)
                ||_parser.Utilities.CompareTokenType(TokenType.OpGreaterThan)
                ||_parser.Utilities.CompareTokenType(TokenType.OpGreaterThanOrEqualTo)
                ||_parser.Utilities.CompareTokenType(TokenType.OpAnd)
                ||_parser.Utilities.CompareTokenType(TokenType.OpLogicalOr)
                ||_parser.Utilities.CompareTokenType(TokenType.OpBitShiftRight)
                ||_parser.Utilities.CompareTokenType(TokenType.OpBitShiftLeft)
                ||_parser.Utilities.CompareTokenType(TokenType.OpEqualTo)
                ||_parser.Utilities.CompareTokenType(TokenType.OpNotEqualTo)
                ||_parser.Utilities.CompareTokenType(TokenType.OpAddAndAssigment)
                ||_parser.Utilities.CompareTokenType(TokenType.OpSusbtractAndAssignment)
                ||_parser.Utilities.CompareTokenType(TokenType.OpMultiplyAndAssignment)
                ||_parser.Utilities.CompareTokenType(TokenType.OpDivideAssignment)
                ||_parser.Utilities.CompareTokenType(TokenType.OpModulusAssignment)
                ||_parser.Utilities.CompareTokenType(TokenType.OpBitwiseAndAssignment)
                ||_parser.Utilities.CompareTokenType(TokenType.OpBitwiseXorAndAssingment)
                ||_parser.Utilities.CompareTokenType(TokenType.OpBitwiseInclusiveOrAndAssigment)
                ||_parser.Utilities.CompareTokenType(TokenType.OpSimpleAssingment))
            {
                RelationalOperators();
                ExpressionAddition();
                RelationalExpressionPrime();
            }
            else
            {
              
            }
        
        }

        private void RelationalOperators()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.OpLessThan))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpLessThanOrEqualTo))
            {
                _parser.Utilities.NextToken();
            }
            else if(_parser.Utilities.CompareTokenType(TokenType.OpGreaterThan))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpGreaterThanOrEqualTo))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpAnd))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpLogicalOr))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpBitShiftRight))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpBitShiftLeft))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpEqualTo))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpNotEqualTo))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpAddAndAssigment))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpSusbtractAndAssignment))
            {
                _parser.Utilities.NextToken();
            }
            else if(_parser.Utilities.CompareTokenType(TokenType.OpMultiplyAndAssignment))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpDivideAssignment))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpModulusAssignment))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpBitwiseAndAssignment))
            {
                _parser.Utilities.NextToken();
            }
            else if(_parser.Utilities.CompareTokenType(TokenType.OpBitwiseXorAndAssingment))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpBitwiseInclusiveOrAndAssigment))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpSimpleAssingment))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                throw new Exception("A relational operator was expected");
            }
        }

        private void ExpressionAddition()
        {
            ExpressionMultiplication();
            ExpressionAdditionPrime();
        }

        private void ExpressionAdditionPrime()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.OpAdd)
                || _parser.Utilities.CompareTokenType(TokenType.OpSubstraction))
            {
                AdditiveOperrators();
                ExpressionMultiplication();
                ExpressionAdditionPrime();
            }
            else
            {
                
            }
           
        }

        private void AdditiveOperrators()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.OpAdd))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpSubstraction))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                throw new Exception("An additive operator was expected here");
            }
        }

        private void ExpressionMultiplication()
        {
            ExpressionUnary();
            ExpressionMultiplicationPrime();
        }

        private void ExpressionMultiplicationPrime()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.OpDivision)
                || _parser.Utilities.CompareTokenType(TokenType.OpMultiplication)
                || _parser.Utilities.CompareTokenType(TokenType.OpModule))
            {
                MultiplicativeOperators();
                ExpressionUnary();
                ExpressionMultiplicationPrime();
            }
            else
            {
                
            }

           
        }

        private void MultiplicativeOperators()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.OpMultiplication))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpDivision))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpModule))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                throw  new Exception("A multiplicative operator was expected");
            }
        }

        private void ExpressionUnary()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.OpComplement)
                ||_parser.Utilities.CompareTokenType(TokenType.OpIncrement)
                ||_parser.Utilities.CompareTokenType(TokenType.OpDecrement)
                ||_parser.Utilities.CompareTokenType(TokenType.OpBitAnd)
                ||_parser.Utilities.CompareTokenType(TokenType.OpBitOr))
            {
                UnaryOperators();
                Factor();
            }
            else
            {
                Factor();
            }
        
        }

        private void UnaryOperators()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.OpComplement))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpIncrement))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpDecrement))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpBitAnd))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpBitOr))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpBitXor))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                throw new Exception("An unary operator was expected");
            }
        }

        private void Factor()
        {
           // _parser.Utilities.NextToken();

            if (_parser.Utilities.CompareTokenType(TokenType.Identifier))
            {
                _parser.Utilities.NextToken();
                FactorFunctionOrArray();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.LiteralNumber) ||
                _parser.Utilities.CompareTokenType(TokenType.LiteralDecimal)
                ||_parser.Utilities.CompareTokenType(TokenType.LiteralChar)
                ||_parser.Utilities.CompareTokenType(TokenType.LiteralDate)
                ||_parser.Utilities.CompareTokenType(TokenType.LiteralFloat)
                ||_parser.Utilities.CompareTokenType(TokenType.LiteralHexadecimal)
                ||_parser.Utilities.CompareTokenType(TokenType.LiteralOctal)
                ||_parser.Utilities.CompareTokenType(TokenType.LiteralString))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                _parser.Utilities.NextToken();
                Expression();
                if (_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
                    _parser.Utilities.NextToken();
                else
                {
                    throw new Exception("Closing parenthesis expected )");
                }
            }
            else
            {
                throw new Exception("Factor was expected");
            }
        }

        private void FactorFunctionOrArray()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                _parser.Functions.CallFunction();
            }
           // else if (_parser.Utilities.CompareTokenType(TokenType.)
           // {
                IndexOrArrawAccess();
            //}
           // else
            //{
               // _parser.Utilities.NextToken();
            //}
          
          
        }

        private void IndexOrArrawAccess()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
            {
                _parser.Utilities.NextToken();

                Expression();

                _parser.Utilities.NextToken();

                IndexOrArrawAccess();

                ArrowOrPointer();

            }
        }

        private void ArrowOrPointer()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.OpPointerStructs))
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.Dot))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                throw new Exception("A pointer access symbol was expected");
            }
        }

        private void ExpresionP()
        {
            //+term ExpresionP
            if (_parser.CurrentToken.TokenType == TokenType.OpAdd)
            {
                _parser.Utilities.NextToken();
                Term();
                ExpresionP();
            }
            //-term ExpresionP
            else if (_parser.CurrentToken.TokenType == TokenType.OpSubstraction)
            {
                _parser.Utilities.NextToken();
                Term();
                ExpresionP();
            }
            // Epsilon
            else
            {

            }
        }

        private void Term()
        {
            Factor();
            TermP();
        }

        private void TermP()
        {
            //*Factor TermP
            if (_parser.CurrentToken.TokenType == TokenType.OpMultiplication)
            {
                _parser.CurrentToken = _parser.Lexer.GetNextToken();
                Factor();
                TermP();
            }
            // / Factor TermP
            else if (_parser.CurrentToken.TokenType == TokenType.OpDivision)
            {
                _parser.CurrentToken = _parser.Lexer.GetNextToken();
                Factor();
                TermP();
            }
            // Epsilon
            else
            {

            }
        }
    }
}