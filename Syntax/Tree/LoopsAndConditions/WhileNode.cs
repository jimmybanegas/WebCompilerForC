using System;
using System.Collections.Generic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.LoopsAndConditions
{
    public class WhileNode : StatementNode
    {
        public ExpressionNode WhileCondition;
        public List<StatementNode> Sentences;
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
