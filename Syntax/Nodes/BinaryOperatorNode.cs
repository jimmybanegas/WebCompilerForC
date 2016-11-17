using Syntax.Tree;

namespace Syntax.Nodes
{
    public abstract class BinaryOperatorNode 
    {
        public ExpressionNode RightOperand;
        public ExpressionNode LeftOperand;
    }
}