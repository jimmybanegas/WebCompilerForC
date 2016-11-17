namespace Syntax.Nodes.Operators
{
    public class LessOrEqualOperatorNode : BinaryOperatorNode
    {
        public LessOrEqualOperatorNode()
        {
          
        }

        public string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "<=" + RightOperand.GenerateCode();
        }
    }
}