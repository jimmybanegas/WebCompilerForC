using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Binary
{
    public class DivisionOperatorNode : BinaryOperatorNode
    {
        public DivisionOperatorNode()
        {

        }

        public override BaseType ValidateSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "/" + RightOperand.GenerateCode();
        }
    }
}