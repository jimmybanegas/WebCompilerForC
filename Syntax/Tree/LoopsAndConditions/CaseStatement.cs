using System.Collections.Generic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.LoopsAndConditions
{
    public class CaseStatement : StatementNode
    {
        public ExpressionNode Expression { get; set; }
        public List<StatementNode> Sentences { get; set; }
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