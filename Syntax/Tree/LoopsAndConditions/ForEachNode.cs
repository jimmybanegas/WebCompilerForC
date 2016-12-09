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
        public override void ValidateSemantic()
        {
            StackContext.Context.Stack.Push(new TypesTable());
            //StackContext.Context.CanDeclareBreak = true;
            //StackContext.Context.CanDeclareReturn = true;
            //StackContext.Context.CanDeclareContinue = true;

            var type = DataType.ValidateTypeSemantic();

            var variable = new TypesTable.Variable
            {
                Accessors = Item.Accessors,
                Pointers = Item.PointerNodes
            };

            StackContext.Context.Stack.Peek().RegisterType(Item.Value,type,Position,variable);
            StackContext.Context.Stack.Pop();
            //StackContext.Context.CanDeclareBreak = false;
            //StackContext.Context.CanDeclareReturn = false;
            //StackContext.Context.CanDeclareContinue = false;

        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}
