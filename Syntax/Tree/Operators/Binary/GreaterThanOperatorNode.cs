using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Binary
{
    public class GreaterThanOperatorNode : BinaryOperatorNode
    {
        public GreaterThanOperatorNode()
        {
          
        }

        public override BaseType ValidateSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + ">" + RightOperand.GenerateCode();
        }
    }
}