namespace Syntax.Tree.Nodes.BaseNodes
{
    public abstract class SentenceNode
    {
        public abstract void ValidateSemantic();
        public abstract string GenerateCode();
    }
}
