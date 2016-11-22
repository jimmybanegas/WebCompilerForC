using System;
using System.Collections.Generic;
using Syntax.Tree.Nodes.Acessors;
using Syntax.Tree.Nodes.BaseNodes;
using Syntax.Tree.Nodes.Declarations;

namespace Syntax.Tree.Nodes.DataTypes
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
