using System;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.Acessors
{
    public class ArrayAccessorNode : AccessorNode
    {
        public ExpressionNode IndexExpression { get; set; }
        public override BaseType Validate(BaseType type)
        {
            throw new NotImplementedException();
        }

        public override string GeneratedCodeAttribute()
        {
            return "[" + IndexExpression.GenerateCode() + "]";
        }
    }
}
