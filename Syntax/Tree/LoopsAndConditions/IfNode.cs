using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

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

            foreach (var statementNode in FalseBlock)
            {
                statementNode.ValidateSemantic();
            }

            StackContext.Context.PastContexts.Add(CodeGuid, StackContext.Context.Stack.Pop());
        }

        public override void Interpret()
        {
            StackContext.Context.Stack.Push(StackContext.Context.PastContexts[CodeGuid]);

            dynamic condition = IfCondition.Interpret();
           
            if (condition.Value)
            {
                if (TrueBlock == null) return;
                foreach (var node in TrueBlock)
                {
                    node.Interpret();
                }
            }
            else
            {
                if (FalseBlock == null) return;
                foreach (var node in FalseBlock)
                {
                    node.Interpret();
                }
            }

            StackContext.Context.PastContexts.Remove(CodeGuid);
            StackContext.Context.Stack.Pop();
        }
    }
}
