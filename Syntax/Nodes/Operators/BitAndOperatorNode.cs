using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax.Nodes.Operators
{
    public class BitAndOperatorNode : BinaryOperatorNode
    {
        public BitAndOperatorNode()
        {
        }

        public string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "&" + RightOperand.GenerateCode();
        }
    }
}
