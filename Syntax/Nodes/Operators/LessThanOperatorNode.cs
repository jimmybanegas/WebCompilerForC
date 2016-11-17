namespace Syntax.Nodes.Operators
{
    public class LessThanOperatorNode : BinaryOperatorNode
    {
        public LessThanOperatorNode()
        {
            ;
        }
        
        public string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "<" + RightOperand.GenerateCode();
        }
    }
}