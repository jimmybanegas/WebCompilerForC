using System.Collections.Generic;
using Lexer;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.LoopsAndConditions
{
    public class ForEachNode : ForLoopNode
    {
        public IdentifierNode DataType;
        public IdentifierNode Item;
        public IdentifierNode List;

        public List<StatementNode> Sentences;

        public Token Position = new Token();
        public override void ValidateSemantic(Token currentToken)
        {
            StackContext.Context.Stack.Push(new TypesTable());

            var type = DataType.ValidateTypeSemantic();

            StackContext.Context.Stack.Peek().RegisterType(Item.Value,type,currentToken);

            //  TypesTable.Instance.RegisterType(List.Value, type);

            StackContext.Context.Stack.Pop();

        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}
