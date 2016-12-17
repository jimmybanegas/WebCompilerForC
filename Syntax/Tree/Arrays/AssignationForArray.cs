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

            var dimension = 1;

            foreach (var accessor in accesorsOfArray.Accessors.OfType<ArrayAccessorNode>())
            {
                var expressionUnaryNode = accessor.IndexExpression as ExpressionUnaryNode;
                if (expressionUnaryNode != null)
                {
                    dynamic val = expressionUnaryNode.Factor.Interpret();

                    dimension *= val.Value;
                }
            }

            List<Value> values = new List<Value>();

            foreach (var node in RightValue)
            {
                dynamic value = node.Interpret();

                values.Add(value);
            }

            StackContext.Context.Stack.Peek().SetArrayVariableValue(ArrayIdentifier.Value,values);
        }
    }
}
