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
        public override void ValidateSemantic()
        {
            ItemDeclaration.ValidateSemantic();

            if (Assignation != null)
            {

                Assignation.LeftValue = ItemDeclaration.DataType;
                Assignation.ValidateSemantic();
            }
          
        }

        public override string Interpret()
        {
            throw new NotImplementedException();
        }
    }
}
