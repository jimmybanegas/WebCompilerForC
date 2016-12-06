using System;
using System.Collections.Generic;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.Declarations
{
    public class MultideclarationNode : TypeOfDeclaration
    {
        public GeneralDeclarationNode GeneralNode;
        public List<IdentifierNode> ListOfVariables;
        public override void ValidateSemantic()
        {

            GeneralNode.ValidateSemantic();

            foreach (var variable in ListOfVariables)
            {
                variable.ValidateSemantic();
                //variable.ValidateTypeSemantic();

                TypesTable.Instance.RegisterType(variable.Value, GeneralNode.DataType.ValidateTypeSemantic());
            }
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
