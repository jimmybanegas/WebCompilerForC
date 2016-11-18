using System.Collections.Generic;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.LoopsAndConditions
{
    public class CaseStatement : StatementNode
    {
        public ExpressionNode Expressions { get; set; }
        public List<StatementNode> Statements { get; set; }
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