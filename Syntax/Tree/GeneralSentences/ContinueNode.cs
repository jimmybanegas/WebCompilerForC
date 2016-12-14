using System;
using Lexer;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.GeneralSentences
{
    public class ContinueNode : StatementNode
    {
        public override void ValidateSemantic()
        {
            //throw new NotImplementedException();
        }

        public override string Interpret()
        {
            throw new NotImplementedException();
        }
    }
}
