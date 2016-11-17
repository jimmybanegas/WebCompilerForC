namespace Syntax.Nodes.Operators
{
    public class GreaterOrEqualOperatorNode : BinaryOperatorNode
    {
        public GreaterOrEqualOperatorNode()
        {
            
        }

        public string GenerateCode()
        {
            return LeftOperand.GenerateCode() + ">=" + RightOperand.GenerateCode();
        }
    }
}