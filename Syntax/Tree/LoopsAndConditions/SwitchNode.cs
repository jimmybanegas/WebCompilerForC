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
        public override void ValidateSemantic()
        {
            StackContext.Context.Stack.Push(new TypesTable());

            var conditional = Expression.ValidateSemantic();

            if (!(conditional is BooleanType))
                throw new SemanticException($"A boolean expression was expected, not a {conditional} at Row: {Position.Row} , Column {Position.Column}");

            foreach (var statement in CaseStatements)
            {
                statement.ValidateSemantic();
            }

            StackContext.Context.Stack.Pop();
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
