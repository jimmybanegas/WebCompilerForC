using System;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.Acessors
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
