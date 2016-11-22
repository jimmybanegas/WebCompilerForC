using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syntax.Tree.Nodes.Acessors;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree
{
    public class IdentifierExpression : ExpressionNode
    {
        public string Value { get; set; }
        public UnaryOperator IncrementOrdecrement { get; set; }
        public List<AccessorNode> Accessors = new List<AccessorNode>();


        public override BaseType ValidateSemantic()
        {
            throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
