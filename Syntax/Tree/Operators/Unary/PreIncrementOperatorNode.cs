using System;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Unary
{
    public class PreIncrementOperatorNode : UnaryOperator
    {
        public override BaseType ValidateSemantic()
        {
            return Operand.ValidateSemantic();
        }

        public override Value Interpret()
        {
           dynamic response = "++" + Operand.Interpret();

            return new BoolValue { Value = response.Value };
        }
    }
}
