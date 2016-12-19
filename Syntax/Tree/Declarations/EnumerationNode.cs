using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.Acessors;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.Declarations
{
    public class EnumerationNode : StatementNode
    {
        public IdentifierNode Name;
        public List<StatementNode> EnumItems;
        public List<string> EnumDeclarations;

        public override void ValidateSemantic()
        {
            List<ElementEnum> items = new List<ElementEnum>();
            
            foreach (var item in EnumItems)
            {
                item.ValidateSemantic();

                items.Add(new ElementEnum {Element = item as EnumItemNode});
            }

            var variable = new TypesTable.Variable
            {
                Accessors = Name.Accessors,
                Pointers = Name.PointerNodes
            };

            StackContext.Context.Stack.Peek().RegisterType(Name.Value,new EnumType(items),Position ,variable);
            StackContext.Context.TableOfTypes.Add(Name.Value, new EnumType(items));

            variable.Accessors = new List<AccessorNode>();
            variable.Pointers = new List<PointerNode>();

            if (EnumDeclarations.Count > 0)
            {
                foreach (var declaration in EnumDeclarations)
                {
                    var type = StackContext.Context.GetGeneralType(Name.Value);

                    StackContext.Context.Stack.Peek().RegisterType(declaration, type, Position, variable);
                  //  StackContext.Context.Stack.Peek().Table.Add(declaration,type);
                }
            }

            foreach (var item in EnumItems)
            {
                var name = ((EnumItemNode) item).ItemName.Value;
                var type = StackContext.Context.GetGeneralType(Name.Value);

                StackContext.Context.Stack.Peek().RegisterType(name, type, Position, variable);
                StackContext.Context.Stack.Peek().SetVariableValue(name,new StringValue {Value = name});
            }
        }

        public override void Interpret()
        {
           
        }
    }
}
