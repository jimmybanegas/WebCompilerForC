using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax.Nodes.Operators
{
    public class AndOperatorNode : BinaryOperatorNode
    {
        public AndOperatorNode()
        {
        }

        public string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "&&" + RightOperand.GenerateCode();
        }
    }
}
