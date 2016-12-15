using System;
using Syntax.Interpret;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Unary
{
    public class ReferenceOperatorNode : UnaryOperator
    {
        public override BaseType ValidateSemantic()
        {
            throw new NotImplementedException();
        }

        public override Value Interpret()
        {
            throw new NotImplementedException();
        }
    }
}