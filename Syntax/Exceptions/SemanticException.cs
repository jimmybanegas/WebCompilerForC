using System;

namespace Syntax.Exceptions
{
    public class SemanticException : Exception
    {
        public SemanticException(string message) : base(message)
        {
            
        }
    }
}