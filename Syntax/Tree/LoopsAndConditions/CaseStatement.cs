using System.Collections.Generic;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.LoopsAndConditions
{
    public class CaseStatement : StatementNode
    {
        public ExpressionNode Expression { get; set; }
        public List<StatementNode> Sentences { get; set; }

        public Token Position = new Token();
        public override void ValidateSemantic(Token currentToken)
        {
            StackContext.Context.Stack.Push(new TypesTable());

            var conditional = Expression.ValidateSemantic();

            if (!(conditional is BooleanType))
                throw new SemanticException($"A boolean expression is expected, not a {conditional}");

            foreach (var statement in Sentences)
            {
                statement.ValidateSemantic(currentToken);
            }

            StackContext.Context.Stack.Pop();
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}