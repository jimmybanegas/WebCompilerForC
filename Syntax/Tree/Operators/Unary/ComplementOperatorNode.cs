using System;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Unary
{
    public class ComplementOperatorNode : UnaryOperator
    {
       public override BaseType ValidateSemantic()
        {
            return new IntType();
        }

        public override Value Interpret()
        {
            dynamic response =  "~"+ Operand.Interpret();

            return new BoolValue { Value = response.Value };
        }
    }
}
