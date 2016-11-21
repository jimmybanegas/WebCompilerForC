using System;
using System.Collections.Generic;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.LoopsAndConditions
{
    public class ForNode : ForLoopNode
    {
        public ExpressionNode FirstCondition;
        public ExpressionNode SecondCondition;
        public ExpressionNode ThirdCondition;
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
