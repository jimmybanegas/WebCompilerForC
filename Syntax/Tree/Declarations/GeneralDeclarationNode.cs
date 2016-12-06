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
        public Token CurrentToken { get; set; }

        public override void ValidateSemantic()
        {
            var type = DataType.ValidateTypeSemantic();

            // TypesTable.Instance.RegisterType(NameOfVariable.Value,type);
            StackContext.Context.Stack.Peek().RegisterType(NameOfVariable.Value, type);

            if (NameOfVariable.Assignation !=null)
            {
               // var typeOfVariable = NameOfVariable.ValidateTypeSemantic();

                NameOfVariable.Assignation.LeftValue = DataType;

                NameOfVariable.Assignation.ValidateSemantic();
            } 
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
