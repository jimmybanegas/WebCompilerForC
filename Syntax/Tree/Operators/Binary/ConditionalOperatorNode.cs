using System;
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

        public override string Interpret()
        {
            return LeftOperand.Interpret() + "?" + RightOperand.Interpret();
        }
    }
}
