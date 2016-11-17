namespace Syntax.Nodes.Operators
{
    public class DivisionOperatorNode : BinaryOperatorNode
    {
        public DivisionOperatorNode()
        {

        }

        public string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "/" + RightOperand.GenerateCode();
        }
    }
}