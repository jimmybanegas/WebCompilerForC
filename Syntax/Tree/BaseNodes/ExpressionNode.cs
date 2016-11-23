namespace Syntax.Tree.BaseNodes
{
    public abstract class ExpressionNode
    {
        public abstract BaseType ValidateSemantic();
        public abstract string GenerateCode();

    }
}
