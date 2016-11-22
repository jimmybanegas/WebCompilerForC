using System;
using System.Collections.Generic;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.Functions
{
    public class FunctionCallNode : StatementNode
    {
        public IdentifierNode Name;
        public List<ExpressionNode> Parameters;
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
