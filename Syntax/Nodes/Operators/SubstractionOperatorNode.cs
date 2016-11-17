namespace Syntax.Nodes.Operators
{
    public class SubstractionOperatorNode : BinaryOperatorNode
    {
        public SubstractionOperatorNode()
        {

        }
        public string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "-" + RightOperand.GenerateCode();
        }
    }
}