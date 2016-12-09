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
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
