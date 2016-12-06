using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Semantic;
using Syntax.Tree.Acessors;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.Declarations
{
    public class GeneralDeclarationNode : StatementNode
    {
        public IdentifierNode DataType;
        public List<PointerNode> ListOfPointer;
        public DeReferenceNode Reference;
        public IdentifierNode NameOfVariable;
     
        public Token Position = new Token();

        public override void ValidateSemantic(Token currentToken)
        {
            var type = DataType.ValidateTypeSemantic();

            // TypesTable.Instance.RegisterType(NameOfVariable.Value,type);
            StackContext.Context.Stack.Peek().RegisterType(NameOfVariable.Value, type,currentToken);

            if (NameOfVariable.Assignation !=null)
            {
               // var typeOfVariable = NameOfVariable.ValidateTypeSemantic();

                NameOfVariable.Assignation.LeftValue = DataType;

                NameOfVariable.Assignation.ValidateSemantic(Position);
            } 
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
