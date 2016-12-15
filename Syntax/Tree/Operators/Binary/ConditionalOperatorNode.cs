using System;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Binary
{
    public class ConditionalOperatorNode : BinaryOperatorNode
    {
        public ConditionalOperatorNode()
        {
        }

        public override BaseType ValidateSemantic()
        {
            throw new NotImplementedException();
        }

        public override Value Interpret()
        {
            dynamic response = LeftOperand.Interpret() + "?" + RightOperand.Interpret();

            return new BoolValue { Value = response.Value };
        }
    }
}
