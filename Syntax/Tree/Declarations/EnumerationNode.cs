using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.Declarations
{
    public class EnumerationNode : StatementNode
    {
        public IdentifierNode Name;
        //public List<TypeOfDeclaration> EnumItems;
        public List<StatementNode> EnumItems;

        public Token Position = new Token();
        public override void ValidateSemantic(Token currentToken)
        {
            List<ElementEnum> items = new List<ElementEnum>();
            
            foreach (var item in EnumItems)
            {
                item.ValidateSemantic(Position);

                items.Add( new ElementEnum {Element = item as EnumItemNode});
            }

            StackContext.Context.Stack.Peek().RegisterType(Name.Value,new EnumType(items),Position );
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
