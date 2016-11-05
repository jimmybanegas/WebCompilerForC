using System;
using Lexer;

namespace Syntax
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