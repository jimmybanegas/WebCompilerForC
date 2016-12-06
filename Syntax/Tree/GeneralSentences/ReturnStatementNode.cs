using System;
using Lexer;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.GeneralSentences
{
    public class ReturnStatementNode : StatementNode
    {
        public ExpressionNode ReturnExpression;

        public Token Position = new Token();
        public override void ValidateSemantic(Token currentToken)
        {
            ReturnExpression.ValidateSemantic();
        }

        public BaseType ValidateSemanticAndGetType()
        {
            return ReturnExpression.ValidateSemantic();
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
