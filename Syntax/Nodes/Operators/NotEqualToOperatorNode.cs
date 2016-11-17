namespace Syntax.Nodes.Operators
{
    public class NotEqualToOperatorNode : BinaryOperatorNode
    {
        public NotEqualToOperatorNode()
        {
          
        }

        public string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "!=" + RightOperand.GenerateCode();
        }
    }
}