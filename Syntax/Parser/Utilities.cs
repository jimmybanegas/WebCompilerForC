using System;
using Lexer;

namespace Syntax.Parser
{
    public class Utilities
    {
        private Parser _parser;

        public Utilities(Parser parser)
        {
            _parser = parser;
        }

        public bool CompareTokenType(TokenType type)
        {
            while (_parser.CurrentToken.TokenType == TokenType.HTMLContent ||
                _parser.CurrentToken.TokenType == TokenType.CloseCCode)
            {
                Console.Write(" " + _parser.CurrentToken.Lexeme + " ");
                _parser.CurrentToken = _parser.Lexer.GetNextToken();
            }

            if (_parser.CurrentToken.TokenType == type)
                return true;
            return false;
        }

        public void NextToken()
        {
            Console.Write(" " + _parser.CurrentToken.Lexeme + " ");
            _parser.CurrentToken = _parser.Lexer.GetNextToken();
        }
    }
}