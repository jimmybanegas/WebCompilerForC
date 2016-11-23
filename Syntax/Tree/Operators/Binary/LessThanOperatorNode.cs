using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Binary
{
    public class LessThanOperatorNode : BinaryOperatorNode
    {
        public LessThanOperatorNode()
        {
            ;
        }

        public override BaseType ValidateSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "<" + RightOperand.GenerateCode();
        }
    }
}