using System;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Binary
{
    class SimpleAssignmentOperatorNode : BinaryOperatorNode
    {
        public override BaseType ValidateSemantic()
        {
            throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "=" + RightOperand.GenerateCode();
        }
    }
}
