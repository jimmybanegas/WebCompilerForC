using System;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.Acessors
{
    public class PointerAccessorNode : AccessorNode
    {
        public IdentifierNode IdentifierNode { get; set; }

        public override BaseType ValidateSemantic()
        {
            var idNodeType = TypesTable.Instance.GetVariable(IdentifierNode.Value);

            return idNodeType;
        }

        public override BaseType ValidateSemanticType(BaseType type)
        {
            if (type is StructType)
            {
                var list = ((StructType)type).Elements;

                foreach (var elementStruct in list)
                {
                    var name = elementStruct.Element.ItemDeclaration.NameOfVariable.Value;

                    if (IdentifierNode.Value == name)
                    {
                        var typeOfElement = elementStruct.Element.ItemDeclaration.DataType.ValidateTypeSemantic();

                        return typeOfElement;
                    }
                }
            }

            throw new SemanticException($"The property {IdentifierNode.Value} doesn't exist in the element");
        }

        public override string GenerateCode()
        {
            return "->" + IdentifierNode.Value;
        }
    }
}
