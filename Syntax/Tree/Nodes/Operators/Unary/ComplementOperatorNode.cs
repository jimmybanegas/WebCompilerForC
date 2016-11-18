using System;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.Operators.Unary
{
    public class ComplementOperatorNode : UnaryOperator
    {
        public ComplementOperatorNode()
        {
        }

        public override BaseType ValidateSemantic()
        {
            throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            return  "~"+ Operand.GenerateCode();
        }
    }
}
