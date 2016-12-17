using System;
using System.Collections.Generic;
using System.Linq;
using Lexer;
using Syntax.Exceptions;
using Syntax.Interpret;
using Syntax.Semantic;
using Syntax.Tree.Acessors;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Declarations;
using Syntax.Tree.Identifier;
using Syntax.Tree.Operators.Unary;

namespace Syntax.Tree.Arrays
{
    public class AssignationForArray : AssignationNode
    {
        public new List<ExpressionNode> RightValue { get; set; }
        public IdentifierNode ArrayIdentifier { get; set; }

        public override void ValidateSemantic()
        {

            foreach (var expressionNode in RightValue)
            {
                var rTipo = expressionNode.ValidateSemantic();

                var variable = new TypesTable.Variable
                {
                    Accessors = LeftValue.Accessors,
                    Pointers = LeftValue.PointerNodes
                };

                if (!StackContext.Context.Stack.Peek().VariableExist(LeftValue.Value))
                    StackContext.Context.Stack.Peek().RegisterType(LeftValue.Value, rTipo, Position, variable);
                else
                {
                    var lTipo = StackContext.Context.Stack.Peek().GetVariable(LeftValue.Value, Position);
                    if (lTipo.GetType() != rTipo.GetType())
                        throw new SemanticException($"You can't assign a {rTipo} to a {lTipo} at Row: {Position.Row} , Column {Position.Column}");
                }

                var accesorsOfArray =
                StackContext.Context.Stack.Peek().GetVariableAccessorsAndPointers(ArrayIdentifier.Value);

                var dimension = 1 ;

                foreach (var accessor in accesorsOfArray.Accessors.OfType<ArrayAccessorNode>())
                {
                    var expressionUnaryNode  = accessor.IndexExpression as ExpressionUnaryNode;
                    if (expressionUnaryNode != null)
                    {
                        dynamic val = expressionUnaryNode.Factor.Interpret();

                        dimension *= val.Value;
                    }
                }

                if (dimension != RightValue.Count)
                {
                    throw new SemanticException($"The index of the array is {dimension}, you're trying to assign {RightValue.Count} at " +
                                                $"Row: {Position.Row} , Column {Position.Column}");
                }

            }
          
        }

        public override void Interpret()
        {
            var accesorsOfArray =
                StackContext.Context.Stack.Peek().GetVariableAccessorsAndPointers(ArrayIdentifier.Value);

           // var dimension = 1;
            int? position1 = null;
            int? position2 = null;

            //foreach (var accessor in accesorsOfArray.Accessors.OfType<ArrayAccessorNode>())
            //{
            //    var expressionUnaryNode = accessor.IndexExpression as ExpressionUnaryNode;
            //    if (expressionUnaryNode != null)
            //    {
            //        dynamic val = expressionUnaryNode.Factor.Interpret();

            //        dimension *= val.Value;
            //    }
            //}

            var accesors = accesorsOfArray.Accessors.OfType<ArrayAccessorNode>();

            var arrayAccessorNodes = accesors as IList<ArrayAccessorNode> ?? accesors.ToList();

            if (arrayAccessorNodes.Count == 1)
            {
                dynamic val = arrayAccessorNodes.First().IndexExpression.Interpret();
                position1 = val.Value;
            }

            if (arrayAccessorNodes.Count == 2)
            {
                dynamic val = arrayAccessorNodes.First().IndexExpression.Interpret();
                dynamic val2 = arrayAccessorNodes.Last().IndexExpression.Interpret();
                position1 = val.Value;
                position2 = val2.Value;
            }

            List<Value> values = new List<Value>();

            int pos1 = 0;
            int pos2 = 0;

            foreach (var node in RightValue)
            {
                dynamic value = node.Interpret();

                if (position2 == null)
                {
                    value.Position1 = pos1;
                }

                if (position2 != null)
                {
                    value.Position1 = pos1;
                    value.Position2 = pos2;
                }

                values.Add(value);

                if (position2 != null)
                {
                    if (pos2 < position2.Value-1)
                    {
                        pos2++;
                    }
                    else
                    {
                        pos1++;
                        pos2 = 0;
                    }
                }
                else
                {
                    if (pos1 < position1.Value)
                    {
                        pos1++;
                    }
                }
             
            }

            StackContext.Context.Stack.Peek().SetArrayVariableValue(ArrayIdentifier.Value,values);
        }
    }
}
