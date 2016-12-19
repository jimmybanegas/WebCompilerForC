using System;
using Syntax.Exceptions;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.Acessors
{
    public class PropertyAccessorNode : AccessorNode
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
                var list = ((StructType) type).Elements;

                foreach (var elementStruct in list)
                {
                     var name =   elementStruct.Element.ItemDeclaration.NameOfVariable.Value;

                    if (IdentifierNode.Value == name)
                    {
                        var typeOfElement = elementStruct.Element.ItemDeclaration.DataType.ValidateTypeSemantic();

                        return typeOfElement;
                    }
                }
            }
            
            throw  new SemanticException($"The property {IdentifierNode.Value} doen't exist in the element");
        }

        public override Value Interpret()
        {
           // return "." + IdentifierNode.Value;

          //  return new IntValue();
          throw new NotImplementedException();
        }
    }
}
