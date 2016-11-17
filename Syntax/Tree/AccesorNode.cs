namespace Syntax.Tree
{
    public abstract class AccesorNode
    {
        public abstract BaseType Validate(BaseType type);
        public abstract string GeneratedCodeAttribute();
    }
}