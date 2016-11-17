using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax.Nodes.Operators
{
    class LessThanOrEqualToOperatorNode : BinaryOperatorNode
    {
        public LessThanOrEqualToOperatorNode()
        {

        }
        public string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "<=" + RightOperand.GenerateCode();
        }
    }
}
