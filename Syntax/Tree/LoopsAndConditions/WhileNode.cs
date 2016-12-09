using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.LoopsAndConditions
{
    public class WhileNode : StatementNode
    {
        public ExpressionNode WhileCondition;
        public List<StatementNode> Sentences;
        public override void ValidateSemantic()
        {
            StackContext.Context.Stack.Push(new TypesTable());
            //StackContext.Context.CanDeclareBreak = true;
            //StackContext.Context.CanDeclareReturn = true;
            //StackContext.Context.CanDeclareContinue = true;

            var conditional = WhileCondition.ValidateSemantic();

            if (!(conditional is BooleanType))
                throw new SemanticException($"A boolean expression is expected, not a {conditional} at Row: {Position.Row} , Column {Position.Column}");

            foreach (var statement in Sentences)
            {
                statement.ValidateSemantic();
            }

            StackContext.Context.Stack.Pop();
            //StackContext.Context.CanDeclareBreak = false;
            //StackContext.Context.CanDeclareReturn = false;
            //StackContext.Context.CanDeclareContinue = false;
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
