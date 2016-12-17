using System;
using Lexer;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.GeneralSentences;

namespace Syntax.Tree.LoopsAndConditions
{
    public class BreakNode : StatementNode
    {
        public override void ValidateSemantic()
        {
           // throw new NotImplementedException();
        }

        public override void Interpret()
        {
            //throw new NotImplementedException();
            return;
        }
        
        public bool InterpretBool()
        {
            //throw new NotImplementedException();
            return true;
        }
    }
}
