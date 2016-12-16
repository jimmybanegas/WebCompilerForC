using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Operators.Binary;
using Syntax.Tree.Operators.Unary;

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

            StackContext.Context.PastContexts.Add(CodeGuid, StackContext.Context.Stack.Pop());
        }

        public override void Interpret()
        {
            StackContext.Context.Stack.Push(StackContext.Context.PastContexts[CodeGuid]);

            FirstCondition.Interpret();
            //SecondCondition.Interpret();
            dynamic conditional1 = ((ExpressionUnaryNode) ((SimpleAssignmentOperatorNode) FirstCondition).LeftOperand).Factor.Interpret();
            dynamic conditional2 = SecondCondition.Interpret();
            //dynamic conditional3 = ThirdCondition.Interpret();

            for (int i = conditional1.Value; conditional2.Value; ThirdCondition.Interpret())
            {
                conditional2 = SecondCondition.Interpret();

                foreach (var statement in Sentences)
                {
                    statement.Interpret();
                }

                Console.WriteLine(conditional1.Value);
            }

            StackContext.Context.PastContexts.Remove(CodeGuid);
            StackContext.Context.Stack.Pop();
        }
    }
}
