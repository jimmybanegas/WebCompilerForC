using System;
using System.Collections.Generic;
using System.Linq;
using Lexer;
using Syntax.Exceptions;
using Syntax.Interpret;
using Syntax.Semantic;
using Syntax.Tree.Acessors;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Operators.Unary;

namespace Syntax.Tree.Identifier
{
    public class IdentifierExpression : ExpressionNode
    {
        public string Name { get; set; }
        public UnaryOperator IncrementOrdecrement { get; set; }

        public List<AccessorNode> Accessors = new List<AccessorNode>();

        public override BaseType ValidateSemantic()
        {
            var type = StackContext.Context.Stack.Peek().GetVariable(Name, Position);

            if (Accessors != null && Accessors.Count>0)
            {
                var accessorsAndPointers = StackContext.Context.Stack.Peek().GetVariableAccessorsAndPointers(Name);

                var arrayAccessorsCount = Accessors.Count(a => a is ArrayAccessorNode);
                var arrayAccessorsCountFromVariable = accessorsAndPointers.Accessors.Count(a => a is ArrayAccessorNode);

                if (arrayAccessorsCountFromVariable != arrayAccessorsCount)
                {
                    throw new SemanticException($"Variable {Name} contains: {arrayAccessorsCountFromVariable} array accessor, " +
                                                $"you're trying to access : {arrayAccessorsCount} at Row: {Position.Row} , Column {Position.Column}");
                }

                foreach (var variable in Accessors)
                {
                      type = variable.ValidateSemanticType(type);
                }
            }

            return type;
        }

        public override Value Interpret()
        {
            if (IncrementOrdecrement != null)
            {
                if (IncrementOrdecrement is PreDecrementOperatorNode)
                {
                    dynamic valueBefore = StackContext.Context.Stack.Peek().GetVariableValue(Name);

                    valueBefore.Value = valueBefore.Value - 1;

                    StackContext.Context.Stack.Peek().SetVariableValue(Name, valueBefore);
                }
                else if (IncrementOrdecrement is PreIncrementOperatorNode)
                {
                    dynamic valueBefore = StackContext.Context.Stack.Peek().GetVariableValue(Name).Clone();

                     valueBefore.Value = valueBefore.Value + 1;

                    //valueBefore.Value = ++valueBefore.Value;

                    StackContext.Context.Stack.Peek().SetVariableValue(Name, valueBefore);
                }
                else if (IncrementOrdecrement is PostIncrementOperatorNode)
                {
                    dynamic valueBefore = StackContext.Context.Stack.Peek().GetVariableValue(Name).Clone();

                     valueBefore.Value = valueBefore.Value + 1;
                  //  valueBefore.Value = valueBefore.Value++;

                    StackContext.Context.Stack.Peek().SetVariableValue(Name, valueBefore);
                }
                else if (IncrementOrdecrement is PostDecrementOperatorNode)
                {
                    dynamic valueBefore = StackContext.Context.Stack.Peek().GetVariableValue(Name);

                    valueBefore.Value = valueBefore.Value - 1;

                    StackContext.Context.Stack.Peek().SetVariableValue(Name, valueBefore);
                }
            }

            if (Accessors != null )
            {
                foreach (var accessor in Accessors)
                {
                    dynamic pos = accessor.Interpret();

                    return StackContext.Context.Stack.Peek().GetArrayVariableValues(Name)[pos.Value - 1];
                }

                throw new SemanticException("Array Index Out of bound exception");
            }

           return StackContext.Context.Stack.Peek().GetVariableValue(Name);
        }
    }
}
