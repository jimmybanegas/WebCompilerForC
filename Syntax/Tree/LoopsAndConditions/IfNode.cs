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
    public class IfNode : StatementNode
    {
        public ExpressionNode IfCondition;
        public List<StatementNode> TrueBlock;
        public List<StatementNode> FalseBlock;
      
        public override void ValidateSemantic()
        {
            StackContext.Context.Stack.Push(new TypesTable());

            var condition = IfCondition.ValidateSemantic();

            if (!(condition is BooleanType))
                throw new SemanticException($"A boolean expression was expected at Row: {Position.Row} , Column {Position.Column}");

            foreach (var statement in TrueBlock)
            {
                statement.ValidateSemantic();
            }

            foreach (var statement in FalseBlock)
            {
                statement.ValidateSemantic();
            }

            StackContext.Context.PastContexts.Add(CodeGuid, StackContext.Context.Stack.Pop());
        }

        public override void Interpret()
        {
            StackContext.Context.Stack.Push(StackContext.Context.PastContexts[CodeGuid]);

            dynamic condition = IfCondition.Interpret();

            var expressionUnaryNode = IfCondition as ExpressionUnaryNode;
            if (expressionUnaryNode?.UnaryOperator is NotOperatorNode)
            {
                condition.Value = !condition.Value;
            }

            if (condition.Value)
            {
                if (TrueBlock == null) return;
                foreach (var node in TrueBlock)
                {
                    if (node is ContinueNode)
                    {
                        continue;
                    }

                    //bool breakN = false;
                    if (node is BreakNode)
                    {
                        goto exit;
                    }

                    //if (breakN) break;

                    if (node is ReturnStatementNode)
                    {
                        return;
                    }

                    node.Interpret();
                }
            }
            else
            {
                if (FalseBlock == null) return;
                foreach (var node in FalseBlock)
                {
                    if (node is ContinueNode)
                    {
                        continue;
                    }

                    if (node is BreakNode)
                    {
                        break;
                    }

                    if (node is ReturnStatementNode)
                    {
                        return;
                    }

                    node.Interpret();
                }
            }
            exit: Console.WriteLine("salit");
            StackContext.Context.Stack.Pop();
        }
    }
}
