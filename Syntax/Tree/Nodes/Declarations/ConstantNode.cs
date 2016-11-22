﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syntax.Tree.Nodes.Acessors;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.Declarations
{
    public class ConstantNode : StatementNode
    {
        public IdentifierNode ConstName;
        public List<PointerNode> PointersList;
        public IdentifierNode TypeOfConst;
        public ExpressionNode ExpressionConst;
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
