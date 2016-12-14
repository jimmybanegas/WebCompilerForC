using System;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Acessors
{
    public class ArrayAccessorNode : AccessorNode
    {
        public ExpressionNode IndexExpression { get; set; }
        public override BaseType ValidateSemantic()
        {
            throw new NotImplementedException();
        }
        
        public override string Interpret()
        {
            return "[" + IndexExpression.Interpret() + "]";
        }

        public override BaseType ValidateSemanticType(BaseType type)
        {
            var expressionType = IndexExpression.ValidateSemantic();

            if (Validations.ValidateReturnTypesEquivalence(type,expressionType))
            {
                return type;
            }

            if (type is StructType)
            {
                return type;
            }

            throw new SemanticException($"Types don't match {type} and {expressionType} at Row: {Position.Row} , Column {Position.Column}");
        }
    }
}
