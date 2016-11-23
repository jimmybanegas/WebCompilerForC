namespace Syntax.Tree.BaseNodes
{
    public abstract class UnaryOperator : ExpressionNode
    {
        public string Value;

        public ExpressionNode Operand;
    }
}
