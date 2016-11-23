namespace Syntax.Tree.BaseNodes
{
    public abstract class BaseType
    {
        public abstract bool IsAssignable(BaseType otherType);
        public abstract string GenerateCode();
    }
}
