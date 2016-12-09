using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.LoopsAndConditions.Functions
{
    public class CallFunctionNode : ExpressionNode
    {
        public string Name;
        public List<ExpressionNode> ListOfExpressions;

        public override BaseType ValidateSemantic()
        {
            var functionType = StackContext.Context.Stack.Peek().GetVariable(Name);

            var o = functionType as FunctionType;
            if (o != null && o.Parameters.Count != ListOfExpressions.Count)
                throw new SemanticException($"You provided {ListOfExpressions.Count} parameters, {o.Parameters.Count} " +
                                            $"are required to call function {Name} at Row: {Position.Row} , Column {Position.Column}");

            int pos = 0;

            foreach (var expression in ListOfExpressions)
            {
                var type = expression.ValidateSemantic();

                var typeInTable = o.Parameters[pos].Parameter.DataType.ValidateTypeSemantic();

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

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
