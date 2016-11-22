namespace Syntax.Tree.Nodes.BaseNodes
{
    public abstract class BinaryOperatorNode : ExpressionNode
    {
        public string Value;
        public ExpressionNode RightOperand; 
        public ExpressionNode LeftOperand;
    }
}