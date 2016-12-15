using System;
using Syntax.Interpret;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Unary
{
    public class PostIncrementOperatorNode : UnaryOperator
    {
        public override BaseType ValidateSemantic()
        {
            return Operand.ValidateSemantic();
        }

        public override Value Interpret()
        {
           // return  "++" ;

            return null;
        }
    }
}
