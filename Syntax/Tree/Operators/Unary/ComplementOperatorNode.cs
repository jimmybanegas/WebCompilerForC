using System;
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

        public override string Interpret()
        {
            return  "~"+ Operand.Interpret();
        }
    }
}
