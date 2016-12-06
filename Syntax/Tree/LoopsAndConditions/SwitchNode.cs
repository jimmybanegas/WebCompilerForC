using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.LoopsAndConditions
{
    public class SwitchNode : StatementNode
    {
        public ExpressionNode Expression;
        public List<CaseStatement> CaseStatements;
        public Token Position = new Token();
        public override void ValidateSemantic(Token currentToken)
        {
            StackContext.Context.Stack.Push(new TypesTable());

            var conditional = Expression.ValidateSemantic();

            if (!(conditional is BooleanType))
                throw new SemanticException($"A boolean expression was expected, not a {conditional}");

            foreach (var statement in CaseStatements)
            {
                statement.ValidateSemantic(currentToken);
            }

            StackContext.Context.Stack.Pop();
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
