using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Binary
{
    public class NotEqualToOperatorNode : BinaryOperatorNode
    {
        public NotEqualToOperatorNode()
        {
          
        }

        public override BaseType ValidateSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "!=" + RightOperand.GenerateCode();
        }
    }
}