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
            if (_parser._currentToken.TokenType == type)
                return true;
            return false;
        }

        public void NextToken()
        {
            Console.Write(" " + _parser._currentToken.Lexeme + " ");
            _parser._currentToken = _parser._lexer.GetNextToken();
        }
    }
}