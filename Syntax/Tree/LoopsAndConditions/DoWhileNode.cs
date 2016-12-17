using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.GeneralSentences;
using Syntax.Tree.Operators.Unary;

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

            if (Sentences != null)
            {
                foreach (var statement in Sentences)
                {
                    statement.ValidateSemantic();
                }
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
                    if (statement is ContinueNode)
                    {
                        continue;
                    }

                    if (statement is BreakNode)
                    {
                        break;
                    }

                    if (statement is ReturnStatementNode)
                    {
                        return;
                    }
                    statement.Interpret();
                }

                conditional = WhileCondition.Interpret();
                var expressionUnaryNode = WhileCondition as ExpressionUnaryNode;
                if (expressionUnaryNode?.UnaryOperator is NotOperatorNode)
                {
                    conditional.Value = !conditional.Value;
                }

            } while (conditional.Value);

            StackContext.Context.Stack.Pop();
        }
    }
}
