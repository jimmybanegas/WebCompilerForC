namespace Syntax.Nodes.Operators
{
    public class AdditionOperatorNode : BinaryOperatorNode
    {

        public AdditionOperatorNode()
        {
        }

        public string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "+" + RightOperand.GenerateCode();
        }
    }
}