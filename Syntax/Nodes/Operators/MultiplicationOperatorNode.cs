namespace Syntax.Nodes.Operators
{
    public class MultiplicationOperatorNode : BinaryOperatorNode
    {

        public MultiplicationOperatorNode()
        {
            
        }

        public string GenerateCode()
        {
            return this.LeftOperand.GenerateCode() + "*" + this.RightOperand.GenerateCode();
        }
    }
}