using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.Operators.Unary
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