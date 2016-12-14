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
            //StackContext.Context.CanDeclareBreak = true;
            //StackContext.Context.CanDeclareReturn = true;
            //StackContext.Context.CanDeclareContinue = true;

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

            StackContext.Context.Stack.Pop();
            //StackContext.Context.CanDeclareBreak = false;
            //StackContext.Context.CanDeclareReturn = false;
            //StackContext.Context.CanDeclareContinue = false;
        }

        public override string Interpret()
        {
            throw new NotImplementedException();
        }
    }
}
