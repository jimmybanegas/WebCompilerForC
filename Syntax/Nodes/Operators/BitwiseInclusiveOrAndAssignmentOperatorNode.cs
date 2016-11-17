namespace Syntax.Nodes.Operators
{
    public class BitwiseInclusiveOrAndAssignmentOperatorNode : BinaryOperatorNode
    {
        public BitwiseInclusiveOrAndAssignmentOperatorNode()
        {
        }

        public string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "|=" + RightOperand.GenerateCode();
        }
    }
}
