using System;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Unary
{
    public class BitOrOperatorNode : UnaryOperator
    {
        public override BaseType ValidateSemantic()
        {
            throw new NotImplementedException();
        }

        public override string Interpret()
        {
            return "|" + Operand.Interpret();
        }
    }
}
