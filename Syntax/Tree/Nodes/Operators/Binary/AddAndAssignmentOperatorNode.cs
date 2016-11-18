using System;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.Operators.Binary
{
    public class AddAndAssignmentOperatorNode : BinaryOperatorNode
    {

        public AddAndAssignmentOperatorNode()
        {
        }

        public override BaseType ValidateSemantic()
        {
            throw new NotImplementedException();
        }

        public override  string  GenerateCode()
        {
            return LeftOperand.GenerateCode() + "+=" + RightOperand.GenerateCode();
        }
    }
}
