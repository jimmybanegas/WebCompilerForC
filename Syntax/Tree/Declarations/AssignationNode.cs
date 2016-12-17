using System;
using System.Collections.Generic;
using System.Linq;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.Acessors;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;
using Syntax.Tree.Operators.Binary;
using Syntax.Tree.Operators.Unary;

namespace Syntax.Tree.Declarations
{
    public class AssignationNode : StatementNode
    {
        public IdentifierNode LeftValue { get; set; }
        public ExpressionNode RightValue { get; set; }

        public override void ValidateSemantic()
        {
            if (LeftValue.Assignation != null)
            {
                var leftIdentifierPointers =
                    StackContext.Context.Stack.Peek().GetVariableAccessorsAndPointers(LeftValue.Value);

                TypesTable.Variable rightIdentifierPointers = null;

                var unaryNode = RightValue as ExpressionUnaryNode;

                var hasDereference = unaryNode != null && (unaryNode.UnaryOperator != null && (unaryNode.UnaryOperator.GetType() ==  typeof(BitAndOperatorNode)));

                var identifierExpression = unaryNode?.Factor as IdentifierExpression;

                if (identifierExpression != null)
                {
                     rightIdentifierPointers = StackContext.Context.Stack.Peek().GetVariableAccessorsAndPointers(identifierExpression.Name);
                }

                if (leftIdentifierPointers.Pointers.Count > 0)
                {
                    if (rightIdentifierPointers != null && rightIdentifierPointers.Pointers.Count == leftIdentifierPointers.Pointers.Count)
                    {
                        
                    }
                    else
                    {
                        int? arrayAccessors = null;
                        if (rightIdentifierPointers != null)
                        {
                             arrayAccessors = rightIdentifierPointers.Accessors.Count(a => a is ArrayAccessorNode);
                        }

                        if (!(leftIdentifierPointers.Pointers.Count > 0 && hasDereference) && 
                            !(leftIdentifierPointers.Pointers.Count > 0 && arrayAccessors > 0) && arrayAccessors !=null)
                        {
                            throw new SemanticException("You need a reference to assignt value to a pointer," +
                                                        $" at Row: {LeftValue.Position.Row}, column : {LeftValue.Position.Column}");
                        }
                    }
                }
            }

            var rTipo = RightValue.ValidateSemantic();

            var variable = new TypesTable.Variable
            {
                Accessors = LeftValue.Accessors,
                Pointers = LeftValue.PointerNodes
            };

            if (!StackContext.Context.Stack.Peek().VariableExist(LeftValue.Value))
                StackContext.Context.Stack.Peek().RegisterType(LeftValue.Value, rTipo,Position,variable);
            else
            {
                var lTipo = StackContext.Context.Stack.Peek().GetVariable(LeftValue.Value,Position);

                if (rTipo is FunctionType)
                {
                    var returnType = (rTipo as FunctionType).FunctValue;

                    if (!Validations.ValidateReturnTypesEquivalence(returnType, lTipo))
                        throw new SemanticException($"You can't assign a {returnType} to a {lTipo} at Row: {Position.Row}, column : {Position.Column}");
                }
                else
                {
                    if (!Validations.ValidateReturnTypesEquivalence(rTipo, lTipo))
                    {
                        if (lTipo is ConstType)
                        {
                            throw new SemanticException($"You can't assign a {rTipo} to a {lTipo} at Row: {LeftValue.Position.Row}, column : {LeftValue.Position.Column}");
                        }
                        var row = Position.Row == 0 ? LeftValue.Position.Row:Position.Row;
                        var column = Position.Column == 0 ? LeftValue.Position.Column : Position.Column;

                        throw new SemanticException($"You can't assign a {rTipo} to a {lTipo} " +
                                                    $"at Row: {row} , column : {column}");
                    }
                }
            }
         
        }

        public override void Interpret()
        {
            dynamic value = RightValue.Interpret();

            var unaryNode = RightValue as ExpressionUnaryNode;

            if (GetValueForUnaries(unaryNode)) return;

            if (unaryNode?.Factor is IdentifierExpression)
            {
                if (!((IdentifierExpression) unaryNode.Factor).Accessors.OfType<ArrayAccessorNode>().Any())
                {
                    value = StackContext.Context.Stack.Peek().GetVariableValue(((IdentifierExpression)unaryNode.Factor).Name).Clone();
                }
            }

            if (unaryNode?.UnaryOperator is NegativeOperatorNode)
            {
                value.Value = value.Value *-1;
            }

            if (unaryNode?.UnaryOperator is NotOperatorNode)
            {
                value.Value = !value.Value;
            }

            int? position1 = null;
            int? position2 = null;
            bool isArray = false;

            if (LeftValue.Accessors != null)
            {
                if (LeftValue.Accessors.OfType<ArrayAccessorNode>().Any())
                {
                    var accesors = LeftValue.Accessors.OfType<ArrayAccessorNode>();

                    var arrayAccessorNodes = accesors as IList<ArrayAccessorNode> ?? accesors.ToList();

                    if (arrayAccessorNodes.Count == 1)
                    {
                        dynamic val = arrayAccessorNodes.First().IndexExpression.Interpret();
                        position1 = val.Value;
                        isArray = true;
                    }

                    if (arrayAccessorNodes.Count == 2)
                    {
                        dynamic val = arrayAccessorNodes.First().IndexExpression.Interpret();
                        dynamic val2 = arrayAccessorNodes.Last().IndexExpression.Interpret();
                        position1 = val.Value;
                        position2 = val2.Value;
                        isArray = true;
                    }
                }
            }


            if (isArray)
            {
                value.Position1 = position1;
                value.Position2 = position2;

                StackContext.Context.Stack.Peek().SetArrayVariableValue(LeftValue.StructValue, value);
                return;
            }

            StackContext.Context.Stack.Peek().SetVariableValue(LeftValue.StructValue,value);
        }

        private bool GetValueForUnaries(ExpressionUnaryNode unaryNode)
        {
            if (unaryNode != null && unaryNode.Type == TokenType.OpAddAndAssignment)
            {
                var a = new AddAndAssignmentOperatorNode
                {
                    LeftOperand = new IdentifierExpression {Name = LeftValue.Value},
                    RightOperand = RightValue
                };

                a.Interpret();
                return true;
            }
            if (unaryNode != null && unaryNode.Type == TokenType.OpSusbtractAndAssignment)
            {
                var a = new SubstractAndAssignmentOperatorNode
                {
                    LeftOperand = new IdentifierExpression {Name = LeftValue.Value},
                    RightOperand = RightValue
                };

                a.Interpret();
                return true;
            }

            if (unaryNode != null && unaryNode.Type == TokenType.OpMultiplyAndAssignment)
            {
                var a = new MultiplicationAndAssignmentOperatorNode
                {
                    LeftOperand = new IdentifierExpression {Name = LeftValue.Value},
                    RightOperand = RightValue
                };

                a.Interpret();
                return true;
            }

            if (unaryNode != null && unaryNode.Type == TokenType.OpDivideAssignment)
            {
                var a = new DivisionAndAssignmentOperatorNode
                {
                    LeftOperand = new IdentifierExpression {Name = LeftValue.Value},
                    RightOperand = RightValue
                };

                a.Interpret();
                return true;
            }

            if (unaryNode != null && unaryNode.Type == TokenType.OpModulusAssignment)
            {
                var a = new ModuleAndAssignmentOperatorNode
                {
                    LeftOperand = new IdentifierExpression {Name = LeftValue.Value},
                    RightOperand = RightValue
                };

                a.Interpret();
                return true;
            }

            if (unaryNode != null && unaryNode.Type == TokenType.OpBitShiftLeftAndAssignment)
            {
                var a = new ShiftLeftAndAssignmentOperatorNode
                {
                    LeftOperand = new IdentifierExpression {Name = LeftValue.Value},
                    RightOperand = RightValue
                };

                a.Interpret();
                return true;
            }

            if (unaryNode != null && unaryNode.Type == TokenType.OpBitShiftRightAndAssignment)
            {
                var a = new ShiftRightAndAssignmentOperatorNode
                {
                    LeftOperand = new IdentifierExpression {Name = LeftValue.Value},
                    RightOperand = RightValue
                };

                a.Interpret();
                return true;
            }
            if (unaryNode != null && unaryNode.Type == TokenType.OpBitwiseAndAssignment)
            {
                var a = new BitwiseAndAssignmentOperatorNode
                {
                    LeftOperand = new IdentifierExpression {Name = LeftValue.Value},
                    RightOperand = RightValue
                };

                a.Interpret();
                return true;
            }

            if (unaryNode != null && unaryNode.Type == TokenType.OpBitwiseXorAndAssignment)
            {
                var a = new BitwiseXorAndAssignmentOperatorNode()
                {
                    LeftOperand = new IdentifierExpression {Name = LeftValue.Value},
                    RightOperand = RightValue
                };

                a.Interpret();
                return true;
            }

            if (unaryNode != null && unaryNode.Type == TokenType.OpBitwiseInclusiveOrAndAssignment)
            {
                var a = new BitwiseInclusiveOrAndAssignmentOperatorNode
                {
                    LeftOperand = new IdentifierExpression {Name = LeftValue.Value},
                    RightOperand = RightValue
                };

                a.Interpret();
                return true;
            }
            return false;
        }
    }
}
