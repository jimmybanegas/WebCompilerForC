using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.LoopsAndConditions
{
    public class SwitchNode : StatementNode
    {
        public ExpressionNode Expression;

        public List<CaseStatement> CaseStatements;
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
