using Syntax.Semantic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.DataTypes
{
    public abstract class LiteralWithOptionalUnaryOpNode : ExpressionNode
    {
        public UnaryOperator UnaryOperator;
    }
}
