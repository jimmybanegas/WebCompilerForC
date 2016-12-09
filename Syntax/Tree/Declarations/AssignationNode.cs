using System;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.Declarations
{
    public class AssignationNode : StatementNode
    {
        public IdentifierNode LeftValue { get; set; }
        public ExpressionNode RightValue { get; set; }

        public override void ValidateSemantic()
        {
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
                var lTipo = StackContext.Context.Stack.Peek().GetVariable(LeftValue.Value);

                if (rTipo is FunctionType)
                {
                    var returnType = (rTipo as FunctionType).FunctValue;

                    if (!Validations.ValidateReturnTypesEquivalence(returnType, lTipo))
                        throw new SemanticException($"You can't assign a {returnType} to a {lTipo} at Row: {Position.Row}, column : {Position.Column}");
                }
                else
                {
                    if (!Validations.ValidateReturnTypesEquivalence(rTipo, lTipo))
                        throw new SemanticException($"You can't assign a {rTipo} to a {lTipo} at Row: {Position.Row}, column : {Position.Column}");
                }
            }
         
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
