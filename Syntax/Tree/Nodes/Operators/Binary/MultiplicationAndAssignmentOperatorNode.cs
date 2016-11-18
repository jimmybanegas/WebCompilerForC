using System;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.Operators.Binary
{
    public class MultiplicationAndAssignmentOperatorNode : BinaryOperatorNode
    {
        public MultiplicationAndAssignmentOperatorNode()
        {
        }

        public override BaseType ValidateSemantic()
        {
            throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "*=" + RightOperand.GenerateCode();
        }
    }
}
