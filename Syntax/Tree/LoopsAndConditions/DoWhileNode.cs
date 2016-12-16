using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.LoopsAndConditions
{
    public class DoWhileNode : StatementNode
    {
        public ExpressionNode WhileCondition;
        public List<StatementNode> Sentences;
        public override void ValidateSemantic()
        {
            StackContext.Context.Stack.Push(new TypesTable());
        
            var conditional = WhileCondition.ValidateSemantic();

            if (!(conditional is BooleanType))
                throw new SemanticException($"A boolean expression was expected, not a {conditional} at Row: {Position.Row} , Column {Position.Column}");

            foreach (var statement in Sentences)
            {
                statement.ValidateSemantic();
            }

            StackContext.Context.PastContexts.Add(CodeGuid, StackContext.Context.Stack.Pop());
        }

        public override void Interpret()
        {
            StackContext.Context.Stack.Push(StackContext.Context.PastContexts[CodeGuid]);
            dynamic conditional;

            do
            {
                foreach (var statement in Sentences)
                {
                    statement.Interpret();
                }

                conditional = WhileCondition.Interpret();
            } while (conditional.Value);

            StackContext.Context.PastContexts.Remove(CodeGuid);
            StackContext.Context.Stack.Pop();
        }
    }
}
