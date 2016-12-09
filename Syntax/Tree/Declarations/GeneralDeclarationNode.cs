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
     
        public override void ValidateSemantic()
        {
            BaseType type;
            if (NameOfVariable.StructValue != null)
            {
                type = StackContext.Context.Stack.Peek().GetVariable(NameOfVariable.StructValue);
            }
            else
            {
                type = DataType.ValidateTypeSemantic();
            }

            var variable = new TypesTable.Variable();
       
            if (NameOfVariable.Accessors != null && NameOfVariable.Accessors.Count > 0)
            {
                variable.Accessors.AddRange(NameOfVariable.Accessors);
            }

            if (ListOfPointer!=null && ListOfPointer.Count > 0)
            {
                variable.Pointers.AddRange(ListOfPointer);
            }

            StackContext.Context.Stack.Peek().RegisterType(NameOfVariable.Value, type,Position,variable);

            if (NameOfVariable.Assignation !=null)
            {
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
