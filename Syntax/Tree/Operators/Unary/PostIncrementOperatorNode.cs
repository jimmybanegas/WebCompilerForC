using System;
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

        public override string Interpret()
        {
            return  "++" ;
        }
    }
}
