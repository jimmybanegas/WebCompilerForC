using Lexer;

namespace Syntax.Tree.BaseNodes
{
    public abstract class StatementNode
    {
        public abstract void ValidateSemantic(Token currentToken);
        public abstract string GenerateCode();

    }
}
