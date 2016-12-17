using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Exceptions;
using Syntax.Interpret;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.GeneralSentences;
using Syntax.Tree.Operators.Unary;

namespace Syntax.Tree.LoopsAndConditions
{
    public class WhileNode : StatementNode
    {
        public ExpressionNode WhileCondition;
        public List<StatementNode> Sentences;
        public override void ValidateSemantic()
        {
            StackContext.Context.Stack.Push(new TypesTable());
     
            var conditional = WhileCondition.ValidateSemantic();

            if (!(conditional is BooleanType))
                throw new SemanticException($"A boolean expression is expected, not a {conditional} at Row: {Position.Row} , Column {Position.Column}");

            foreach (var statement in Sentences)
            {
                statement.ValidateSemantic();
            }

            StackContext.Context.PastContexts.Add(CodeGuid, StackContext.Context.Stack.Pop());
        }

        public override void Interpret()
        {
            StackContext.Context.Stack.Push(StackContext.Context.PastContexts[CodeGuid]);

            dynamic conditional = WhileCondition.Interpret();

            var expressionUnaryNode = WhileCondition as ExpressionUnaryNode;
            if (expressionUnaryNode?.UnaryOperator is NotOperatorNode)
            {
                conditional.Value = !conditional.Value;
            }

            while (conditional.Value)
            {
                foreach (var statement in Sentences)
                {
                    statement.Interpret();

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
                }

                conditional = WhileCondition.Interpret();
            }

            //StackContext.Context.PastContexts.Remove(CodeGuid);
            StackContext.Context.Stack.Pop();
        }
    }
}
