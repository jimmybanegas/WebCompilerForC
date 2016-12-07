using System;
using System.Collections;
using System.Collections.Generic;
using Lexer;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.Struct
{
    public  class StructNode : StatementNode
    {
        public IdentifierExpression Name;
        public List<StructItemNode> ListOfItems;
        private Token Position { get; set; }
        public override void ValidateSemantic(Token currentToken)
        {
            //Name.ValidateSemantic();
                
            List<ElementStruct> elements = new List<ElementStruct>();

            foreach (var item in ListOfItems)
            {
                item.ValidateSemantic(Position);

                elements.Add( new ElementStruct {Element = item});

                StackContext.Context.Stack.Peek().Table.Remove(item.ItemDeclaration.NameOfVariable.Value);
            }

            StackContext.Context.Stack.Peek().RegisterType(Name.Name, new StructType (elements), currentToken );
            StackContext.Context.TableOfTypes.Add(Name.Name, new StructType(elements));
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
