using Lexer;
using Syntax.Interpret;
using Syntax.Semantic;

namespace Syntax.Tree.BaseNodes
{
    public abstract class ExpressionNode
    {
        public  Token Position = new Token();
        public abstract BaseType ValidateSemantic();
        public abstract Value Interpret();

    }
}
