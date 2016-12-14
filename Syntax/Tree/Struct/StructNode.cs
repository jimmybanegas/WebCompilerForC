using System;
using System.Collections;
using System.Collections.Generic;
using Lexer;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.Acessors;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.Struct
{
    public  class StructNode : StatementNode
    {
        public IdentifierExpression Name;
        public List<StructItemNode> ListOfItems;
        public override void ValidateSemantic()
        {
            //Name.ValidateSemantic();
                
            List<ElementStruct> elements = new List<ElementStruct>();

            foreach (var item in ListOfItems)
            {
                item.ValidateSemantic();

                elements.Add( new ElementStruct {Element = item});

                StackContext.Context.Stack.Peek().Table.Remove(item.ItemDeclaration.NameOfVariable.Value);
                StackContext.Context.Stack.Peek().Variables.Remove(item.ItemDeclaration.NameOfVariable.Value);
            }

            var variable = new TypesTable.Variable
            {
                Accessors = Name.Accessors,
                Pointers = new List<PointerNode>()
            };

            StackContext.Context.Stack.Peek().RegisterType(Name.Name, new StructType (elements), Position, variable );
            StackContext.Context.TableOfTypes.Add(Name.Name, new StructType(elements));
        }

        public override string Interpret()
        {
            throw new NotImplementedException();
        }
    }
}
