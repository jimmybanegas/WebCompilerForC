namespace Syntax.Tree.BaseNodes
{
    public abstract class StatementNode
    {
        public abstract void ValidateSemantic();
        public abstract string GenerateCode();
    }
}
