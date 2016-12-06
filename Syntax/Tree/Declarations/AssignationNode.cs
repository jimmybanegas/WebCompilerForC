using System;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.Declarations
{
    public class AssignationNode : StatementNode
    {
        public IdentifierNode LeftValue { get; set; }
        public ExpressionNode RightValue { get; set; }

        public Token Position = new Token();

        public override void ValidateSemantic(Token currentToken)
        {
            var rTipo = RightValue.ValidateSemantic();

            if (!StackContext.Context.Stack.Peek().VariableExist(LeftValue.Value))
                StackContext.Context.Stack.Peek().RegisterType(LeftValue.Value, rTipo,currentToken);
            else
            {
                var lTipo = StackContext.Context.Stack.Peek().GetVariable(LeftValue.Value);
                
             //   if (lTipo.GetType() != rTipo.GetType())
                if (!Validations.ValidateReturnTypesEquivalence(rTipo,lTipo))
                    throw new SemanticException($"You can't assign a {rTipo} to a {lTipo} at Row: {currentToken.Row}, column : {currentToken.Column}");
            }
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
