using System;
using Lexer;

namespace Syntax
{
    public class Expressions
    {
        private Parser _parser;

        public Expressions(Parser parser)
        {
            _parser = parser;
        }

        public void Expression()
        {
            Term();
            ExpresionP();
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

        private void Factor()
        {
            if (_parser.CurrentToken.TokenType == TokenType.Identifier)
            {
                _parser.CurrentToken = _parser.Lexer.GetNextToken();

            }
            else if (_parser.CurrentToken.TokenType == TokenType.LiteralNumber)
            {
                _parser.CurrentToken = _parser.Lexer.GetNextToken();

            }
            else if (_parser.CurrentToken.TokenType == TokenType.OpenParenthesis)
            {
                _parser.CurrentToken = _parser.Lexer.GetNextToken();
                Expression();
                if (_parser.CurrentToken.TokenType == TokenType.CloseParenthesis)
                    _parser.CurrentToken = _parser.Lexer.GetNextToken();
                else
                {
                    throw new Exception("Se esperaba )");
                }
            }
            else
            {
                throw new Exception("Se esperaba un Factor");
            }
        }
    }
}