using System;

namespace Syntax.Semantic.Types
{
    public class EnumType : BaseType
    {
        public override string ToString()
        {
            return "Enum";
        }

        public override bool IsAssignable(BaseType otherType)
        {
            throw new NotImplementedException();
        }
    }
}