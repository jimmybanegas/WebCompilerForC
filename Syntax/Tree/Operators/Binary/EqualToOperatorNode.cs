using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Binary
{
    public class EqualToOperatorNode : BinaryOperatorNode
    {
        public EqualToOperatorNode()
        {
            
        }

        public override BaseType ValidateSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "==" + RightOperand.GenerateCode();
        }
    }
}