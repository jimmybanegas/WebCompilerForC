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

        public void Expresion()
        {
            Term();
            ExpresionP();
        }

        private void ExpresionP()
        {
            //+term ExpresionP
            if (_parser._currentToken.TokenType == TokenType.OpAdd)
            {
                _parser.Utilities.NextToken();
                Term();
                ExpresionP();
            }
            //-term ExpresionP
            else if (_parser._currentToken.TokenType == TokenType.OpSubstraction)
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
            if (_parser._currentToken.TokenType == TokenType.OpMultiplication)
            {
                _parser._currentToken = _parser._lexer.GetNextToken();
                Factor();
                TermP();
            }
            // / Factor TermP
            else if (_parser._currentToken.TokenType == TokenType.OpDivision)
            {
                _parser._currentToken = _parser._lexer.GetNextToken();
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
            if (_parser._currentToken.TokenType == TokenType.Identifier)
            {
                _parser._currentToken = _parser._lexer.GetNextToken();

            }
            else if (_parser._currentToken.TokenType == TokenType.LiteralNumber)
            {
                _parser._currentToken = _parser._lexer.GetNextToken();

            }
            else if (_parser._currentToken.TokenType == TokenType.OpenParenthesis)
            {
                _parser._currentToken = _parser._lexer.GetNextToken();
                Expresion();
                if (_parser._currentToken.TokenType == TokenType.CloseParenthesis)
                    _parser._currentToken = _parser._lexer.GetNextToken();
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