using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.LoopsAndConditions.Functions
{
    public class FunctionCallNode : StatementNode
    {
        public IdentifierNode Name;

        public List<ExpressionNode> Parameters;

        public Token Position = new Token();
        public override void ValidateSemantic(Token currentToken)
        {
            //throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
