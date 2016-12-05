using System;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.Acessors
{
    public class PropertyAccessorNode : AccessorNode
    {
        public IdentifierNode IdentifierNode { get; set; }
        public override BaseType ValidateSemantic()
        {
            var idNodeType = TypesTable.Instance.GetVariable(IdentifierNode.Value);

            return idNodeType;
        }

        public override BaseType ValidateSemanticType(string type)
        {
           
            var idNodeType = TypesTable.Instance.GetVariable(IdentifierNode.Value);

            return idNodeType;
        }

        public override string GenerateCode()
        {
            return "." + IdentifierNode.Value;
        }
    }
}
