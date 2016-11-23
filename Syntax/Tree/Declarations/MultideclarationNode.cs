using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
