using System;
using Lexer;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.GeneralSentences
{
    public class IncludeNode : StatementNode
    {
        public string ReferencedClass;

        public Token Position = new Token();
        public override void ValidateSemantic(Token currentToken)
        {
           // throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
