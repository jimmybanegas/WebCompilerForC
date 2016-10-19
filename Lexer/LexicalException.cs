using System;

namespace Lexer
{
    public class LexicalException : Exception
    {
        public LexicalException(string message) : base(message)
        {
        }
    }
}