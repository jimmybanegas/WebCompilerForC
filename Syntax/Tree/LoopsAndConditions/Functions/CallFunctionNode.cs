using System;
using System.Collections.Generic;
using System.Linq;
using Lexer;
using Syntax.Exceptions;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.Acessors;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;
using Syntax.Tree.Operators.Unary;

namespace Syntax.Tree.LoopsAndConditions.Functions
{
    public class CallFunctionNode : ExpressionNode
    {
        public string Name;
        public List<ExpressionNode> ListOfExpressions;

        public override BaseType ValidateSemantic()
        {
            var functionType = StackContext.Context.Stack.Peek().GetVariable(Name,Position);

            var o = functionType as FunctionType;
            if (o != null && o.Parameters.Count != ListOfExpressions.Count)
                throw new SemanticException($"You provided {ListOfExpressions.Count} parameters, {o.Parameters.Count} " +
                                            $"are required to call function {Name} at Row: {Position.Row} , Column {Position.Column}");

            int pos = 0;

            foreach (var expression in ListOfExpressions)
            {
                var type = expression.ValidateSemantic();

                var typeInTable = o.Parameters[pos].Parameter.DataType.ValidateTypeSemantic();


                if (o.Parameters[pos].Parameter.ListOfPointer != null)
                {
                    if (((ExpressionUnaryNode)expression).UnaryOperator == null)
                    {
                        throw new SemanticException($"Expected *{typeInTable} at Row: {Position.Row} , Column {Position.Column} but you provided an {type}");
                    }

                    if (!(((ExpressionUnaryNode)expression).Factor is IdentifierExpression))
                    {
                        throw new SemanticException($"An Identifier is expected at Row: {Position.Row} , Column {Position.Column} but you provided a " +
                                                    $" { ((ExpressionUnaryNode)expression).Factor }");
                    }
                }

                if (type is FunctionType)
                {
                    var returnType = (type as FunctionType).FunctValue;

                    if (!(Validations.ValidateReturnTypesEquivalence(returnType, typeInTable)))
                        throw new SemanticException($"You provided a {returnType} as parameter, {typeInTable} " +
                                                    $"is required as parameter in position {pos + 1} at Row: {Position.Row} , Column {Position.Column}");
                }
                else
                {
                    if (!(Validations.ValidateReturnTypesEquivalence(type, typeInTable)))
                        throw new SemanticException($"You provided a {type} as parameter, {typeInTable} " +
                                                    $"is required as parameter in position {pos + 1} at Row: {Position.Row} , Column {Position.Column}");
                }

                pos++;
            }

            return functionType;
        }

        public override Value Interpret()
        {
            var functiondeclaration = StackContext.Context.FunctionsNodes[Name];

            StackContext.Context.Stack.Push(StackContext.Context.PastContexts[functiondeclaration.CodeGuid]);
            
            int pos = 0;
            foreach (var parameter in functiondeclaration.Parameters)
            {
                string name = null;
                var isArray = false;
                var expressionUnaryNode  = ListOfExpressions[pos] as ExpressionUnaryNode;
                var identifierExpression = expressionUnaryNode?.Factor as IdentifierExpression;

                if (identifierExpression != null)
                {
                    name = identifierExpression.Name ;
                }
                if (name != null)
                {
                    isArray = StackContext.Context.Stack.Peek().GetVariableAccessorsAndPointers(name).Accessors.OfType<ArrayAccessorNode>().Any();
                }

                if (isArray)
                {
                    var values = StackContext.Context.Stack.Peek().GetArrayVariableValues(name);

                    StackContext.Context.Stack.Peek().SetArrayVariableValue(parameter.NameOfVariable.Value,values);
                }
                {
                    dynamic valueOfParameter = ListOfExpressions[pos].Interpret();

                     if (expressionUnaryNode?.UnaryOperator is BitAndOperatorNode)
                    {
                        valueOfParameter.Pointer =
                            ((IdentifierExpression) ((ExpressionUnaryNode) ListOfExpressions[pos]).Factor).Name;
                    }

                    StackContext.Context.Stack.Peek().SetVariableValue(parameter.NameOfVariable.Value, valueOfParameter);
                }
               
                pos++;
            }
            
            var returnValue = functiondeclaration.Execute();

            StackContext.Context.Stack.Pop();

            return returnValue;
        }
    }
}
