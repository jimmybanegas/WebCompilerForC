using System;
using Lexer;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.GeneralSentences
{
    public class IncludeNode : StatementNode
    {
        public string ReferencedClass;

        public override void ValidateSemantic()
        {
           // throw new NotImplementedException();
        }

        public override void Interpret()
        {
            throw new NotImplementedException();
        }
    }
}
