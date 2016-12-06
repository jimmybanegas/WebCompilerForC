using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.Declarations
{
    public class MultideclarationNode : TypeOfDeclaration
    {
        public GeneralDeclarationNode GeneralNode;
        public List<IdentifierNode> ListOfVariables;
        public Token Position = new Token();

        public override void ValidateSemantic(Token currentToken)
        {
            GeneralNode.ValidateSemantic(Position);

            var type = GeneralNode.DataType.ValidateTypeSemantic();

            foreach (var variable in ListOfVariables)
            {
                StackContext.Context.Stack.Peek().RegisterType(variable.Value, type,currentToken);

                variable.ValidateSemantic(Position);

                //var type = GeneralNode.DataType.ValidateTypeSemantic();
                //variable.ValidateTypeSemantic();

            }
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
