namespace Syntax.Nodes.Operators
{
    public class EqualToOperatorNode : BinaryOperatorNode
    {
        public EqualToOperatorNode()
        {
            
        }

        public string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "==" + RightOperand.GenerateCode();
        }
    }
}