namespace Syntax.Nodes.Operators
{
    public class GreaterThanOperatorNode : BinaryOperatorNode
    {
        public GreaterThanOperatorNode()
        {
          
        }

        public string GenerateCode()
        {
            return LeftOperand.GenerateCode() + ">" + RightOperand.GenerateCode();
        }
    }
}