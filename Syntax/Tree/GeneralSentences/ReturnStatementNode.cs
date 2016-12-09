using System;
using Lexer;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.GeneralSentences
{
    public class ReturnStatementNode : StatementNode
    {
        public ExpressionNode ReturnExpression;

        public override void ValidateSemantic()
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
