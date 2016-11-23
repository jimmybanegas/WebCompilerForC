using System;
using System.Collections.Generic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.LoopsAndConditions
{
    public class IfNode : StatementNode
    {
        public ExpressionNode IfCondition;
        public List<StatementNode> TrueBlock;
        public List<StatementNode> FalseBlock;

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
