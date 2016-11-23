using System;
using System.Collections.Generic;
using Syntax.Tree.Acessors;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Declarations;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.DataTypes
{
    public class ConstantNode : StatementNode
    {
        public IdentifierNode ConstName;
        public List<PointerNode> PointersList;
        public IdentifierNode TypeOfConst;
        //public ExpressionNode ExpressionConst;
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
