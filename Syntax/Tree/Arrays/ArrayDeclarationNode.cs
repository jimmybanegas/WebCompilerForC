using System;
using System.Collections.Generic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Arrays
{
    public class ArrayDeclarationNode : StatementNode
    {
        public List<ExpressionNode> Initialization;
        public override void ValidateSemantic()
        {
           // throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
