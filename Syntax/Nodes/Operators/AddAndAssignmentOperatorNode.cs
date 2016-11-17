using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax.Nodes.Operators
{
    public class AddAndAssignmentOperatorNode : BinaryOperatorNode
    {

        public AddAndAssignmentOperatorNode()
        {
        }

        public string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "+=" + RightOperand.GenerateCode();
        }
    }
}
