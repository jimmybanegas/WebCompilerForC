using Syntax.Interpret;

namespace Syntax.Semantic.Types
{
    public class VoidType : BaseType
    {
        public override Value GetDefaultValue()
        {
            throw new System.NotImplementedException();
        }
    }
}