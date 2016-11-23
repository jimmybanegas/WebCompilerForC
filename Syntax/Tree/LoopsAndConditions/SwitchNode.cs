using System;
using System.Collections.Generic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.LoopsAndConditions
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
