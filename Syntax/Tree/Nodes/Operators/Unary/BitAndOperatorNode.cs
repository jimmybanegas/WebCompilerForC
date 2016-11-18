using System;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.Operators.Unary
{
    public class BitAndOperatorNode : UnaryOperator
    {
        public BitAndOperatorNode()
        {
        }

        public override BaseType ValidateSemantic()
        {
            throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            return  "&" + Operand.GenerateCode();
        }
    }
}
