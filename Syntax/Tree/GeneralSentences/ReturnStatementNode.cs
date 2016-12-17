using System;
using Lexer;
using Syntax.Interpret;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.GeneralSentences
{
    public class ReturnStatementNode : StatementNode
    {
        public ExpressionNode ReturnExpression;

        public override void ValidateSemantic()
        {
            ReturnExpression?.ValidateSemantic();
        }

        public BaseType ValidateSemanticAndGetType()
        {
            return ReturnExpression?.ValidateSemantic();
        }

        public override void Interpret()
        {
           // throw new NotImplementedException();
        }

        public Value GetValueOfReturn()
        {
            return ReturnExpression.Interpret();
        }
    }
}
