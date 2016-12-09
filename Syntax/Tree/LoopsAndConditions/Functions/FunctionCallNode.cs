using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Declarations;
using Syntax.Tree.Identifier;
using Syntax.Tree.Operators.Unary;

namespace Syntax.Tree.LoopsAndConditions.Functions
{
    public class FunctionCallNode : StatementNode
    {
        public IdentifierNode Name;

        public List<ExpressionNode> Parameters;
        public override void ValidateSemantic()
        {
            var functionType = StackContext.Context.Stack.Peek().GetVariable(Name.Value);

            var o  = functionType as FunctionType;

            if (o != null && o.Parameters.Count != Parameters.Count)
               throw new SemanticException($"You provided {Parameters.Count} parameters, {o.Parameters.Count} " +
                                           $"are required to call function {Name.Value} at Row: {Position.Row} , Column {Position.Column}");

            int pos = 0;

            foreach (var expression in Parameters)
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
                
                if (!(Validations.ValidateReturnTypesEquivalence(type,typeInTable)))
                    throw new SemanticException($"You provided a {type} as parameter, {typeInTable} " +
                                                $"is required as parameter in position {pos+1} at Row: {Position.Row} , Column {Position.Column}");

                pos++;
            }
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
