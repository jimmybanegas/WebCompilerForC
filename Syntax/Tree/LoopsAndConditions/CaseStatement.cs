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
        public override void ValidateSemantic()
        {
            StackContext.Context.Stack.Push(new TypesTable());

            if (Expression != null)
            {
                var conditional = Expression.ValidateSemantic();
            }

            //if (!(conditional is BooleanType))
            //    throw new SemanticException($"A boolean expression is expected, not a {conditional} at Row: {Position.Row} , Column {Position.Column}");

            foreach (var statement in Sentences)
            {
                statement.ValidateSemantic();
            }

            StackContext.Context.Stack.Pop();
        }

        public override string Interpret()
        {
            throw new System.NotImplementedException();
        }
    }
}