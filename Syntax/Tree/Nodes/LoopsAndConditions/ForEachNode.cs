using System.Collections.Generic;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.LoopsAndConditions
{
    public class ForEachNode : StatementNode
    {
        public ExpressionNode FirstCondition;
        public ExpressionNode SecondCondition;
        public ExpressionNode ThirdCondition;
        public List<StatementNode> Sentences;

        public override void ValidateSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}
