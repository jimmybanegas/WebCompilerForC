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

            if (Accessors != null && Accessors.OfType<ArrayAccessorNode>().Any() )
            {
                if (Accessors.Count == 1 )
                {
                    dynamic pos = ((ArrayAccessorNode)Accessors[0]).IndexExpression.Interpret();

                    var values = StackContext.Context.Stack.Peek().GetArrayVariableValues(Name);

                    foreach (var value in values)
                    {
                        if (value.Position1 == pos.Value)
                        {
                            return value;
                        }
                    }
                    throw new Exception("Index not in array");

                }
                else
                {
                    dynamic pos = ((ArrayAccessorNode)Accessors[0]).IndexExpression.Interpret();
                    dynamic pos2 = ((ArrayAccessorNode) Accessors[1]).IndexExpression.Interpret();

                    var values = StackContext.Context.Stack.Peek().GetArrayVariableValues(Name);

                    foreach (var value in values)
                    {
                        if (value.Position1 == pos.Value && value.Position2 == pos2.Value)
                        {
                            return value;
                        }
                    }
                    throw new Exception("Index not in array");
                }

            }

            if (Accessors != null && Accessors.OfType<PropertyAccessorNode>().Any())
            {
                var nameOfProperty = ((PropertyAccessorNode) Accessors[0]).IdentifierNode.Value;

                var valuesOfStructInstance = StackContext.Context.Stack.Peek().GetStructVariableValues(Name);

                foreach (var tuple in valuesOfStructInstance)
                {
                    if (tuple.Item1 == nameOfProperty)
                    {
                        return tuple.Item2;
                    }
                }
            }

            return StackContext.Context.Stack.Peek().GetVariableValue(Name);
        }
    }
}
