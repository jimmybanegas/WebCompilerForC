using System;
using Syntax.Semantic;
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

        public override string GenerateCode()
        {
            return "[" + IndexExpression.GenerateCode() + "]";
        }
    }
}
