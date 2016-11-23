using System;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Declarations;

namespace Syntax.Tree.Struct
{
    public  class StructItemNode : StatementNode
    {
        public GeneralDeclarationNode ItemDeclaration;
        public AssignationNode Assignation;
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
