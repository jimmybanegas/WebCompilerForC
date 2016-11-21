using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.DataTypes
{
    public abstract class LiteralWithOptionalUnaryOpNode : ExpressionNode
    {
        public UnaryOperator UnaryOperator;
    }
}
