using System;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Unary
{
    public class PreDecrementOperatorNode : UnaryOperator
    {
        public override BaseType ValidateSemantic()
        {
            return Operand.ValidateSemantic();
        }

        public override string GenerateCode()
        {
            return "--" + Operand.GenerateCode();
        }
    }
}
