using System;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.Acessors
{
    public class PointerAccessorNode : AccessorNode
    {
        public IdentifierNode IdentifierNode { get; set; }

        public override BaseType ValidateSemantic()
        {
            throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            return "->" + IdentifierNode.Value;
        }
    }
}
