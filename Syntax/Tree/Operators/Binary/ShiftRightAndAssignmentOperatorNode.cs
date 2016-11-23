using System;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Binary
{
    public class ShiftRightAndAssignmentOperatorNode : BinaryOperatorNode
    {
        public ShiftRightAndAssignmentOperatorNode()
        {
        }

        public override BaseType ValidateSemantic()
        {
            throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + ">>=" + RightOperand.GenerateCode();
        }
    }
}
