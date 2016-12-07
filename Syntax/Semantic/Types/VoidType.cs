namespace Syntax.Semantic.Types
{
    public class VoidType : BaseType
    {
        public override bool IsAssignable(BaseType otherType)
        {
            throw new System.NotImplementedException();
        }
    }
}