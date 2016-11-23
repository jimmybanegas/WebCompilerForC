using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
