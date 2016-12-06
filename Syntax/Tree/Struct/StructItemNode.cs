using System;
using Lexer;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Declarations;

namespace Syntax.Tree.Struct
{
    public  class StructItemNode : StatementNode
    {
        public GeneralDeclarationNode ItemDeclaration;
        public AssignationNode Assignation;
        public override void ValidateSemantic(Token currentToken)
        {
            throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
