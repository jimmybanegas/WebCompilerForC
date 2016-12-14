using System;
using Lexer;
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
            var idNodeType = TypesTable.Instance.GetVariable(IdentifierNode.Value, Position);

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

            throw new SemanticException($"The property {IdentifierNode.Value} doesn't exist in the element at Row: {Position.Row} , Column {Position.Column}");
        }

        public override string Interpret()
        {
            return "->" + IdentifierNode.Value;
        }
    }
}
