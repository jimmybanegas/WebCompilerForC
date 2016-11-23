using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Unary
{
    public class NotOperatorNode : UnaryOperator
    {

        public override BaseType ValidateSemantic()
        {
            return null;
        }

        public override string GenerateCode()
        {
            return "!" + Operand.GenerateCode();
        }
    }
}