using Syntax.Semantic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Acessors
{
    public abstract class AccessorNode : ExpressionNode
    {
        public abstract BaseType ValidateSemanticType(BaseType type);
        //  public abstract BaseType Validate(BaseType type);
        // public abstract string GeneratedCodeAttribute();
    }
}