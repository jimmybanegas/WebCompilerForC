using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Unary
{
    public class NotOperatorNode : UnaryOperator
    {

        public override BaseType ValidateSemantic()
        {
            return new BooleanType();
        }

        public override string GenerateCode()
        {
            return "!" + Operand.GenerateCode();
        }
    }
}