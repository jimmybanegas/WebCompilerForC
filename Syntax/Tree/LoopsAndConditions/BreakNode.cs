using System;
using Lexer;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.LoopsAndConditions
{
    public class BreakNode : StatementNode
    {
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
