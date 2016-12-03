using System;

namespace Syntax.Semantic.Types
{
    public class StructType : BaseType
    {
        public override string ToString()
        {
            return "Struct";
        }

        public override bool IsAssignable(BaseType otherType)
        {
            throw new NotImplementedException();
        }
    }
}