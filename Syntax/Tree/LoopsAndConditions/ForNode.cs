using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.LoopsAndConditions
{
    public class ForNode : ForLoopNode
    {
        public ExpressionNode FirstCondition;
        public ExpressionNode SecondCondition;
        public ExpressionNode ThirdCondition;
        public List<StatementNode> Sentences;
        public override void ValidateSemantic()
        {
            StackContext.Context.Stack.Push(new TypesTable());
            //StackContext.Context.CanDeclareBreak = true;
            //StackContext.Context.CanDeclareReturn = true;
            //StackContext.Context.CanDeclareContinue = true;


            var conditional1 = FirstCondition.ValidateSemantic();
            var conditional2 = SecondCondition.ValidateSemantic();
            var conditional3 = ThirdCondition.ValidateSemantic();

            if (!(conditional1 is IntType))
                throw new SemanticException($"An Integer expression is expected at Row: {Position.Row} , Column {Position.Column}");

            if (!(conditional2 is BooleanType))
                throw new SemanticException($"A boolean expression is expected at Row: {Position.Row} , Column {Position.Column}");

            if (!(conditional3 is IntType))
                throw new SemanticException($"An Integer expression is expected at Row: {Position.Row} , Column {Position.Column}");

            foreach (var statement in Sentences)
            {
                statement.ValidateSemantic();
            }

            StackContext.Context.Stack.Pop();
            //StackContext.Context.CanDeclareBreak = false;
            //StackContext.Context.CanDeclareReturn = false;
            //StackContext.Context.CanDeclareContinue = false;
        }

        public override void Interpret()
        {
            throw new NotImplementedException();
        }
    }
}
