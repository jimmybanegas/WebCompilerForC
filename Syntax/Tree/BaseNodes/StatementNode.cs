using System;
using Lexer;

namespace Syntax.Tree.BaseNodes
{
    public abstract class StatementNode
    {
        public Token Position = new Token();
        public abstract void ValidateSemantic();
        public abstract void Interpret();

        public Guid CodeGuid = Guid.NewGuid();
    }
}
