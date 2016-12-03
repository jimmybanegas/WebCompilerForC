using System;

namespace Syntax.Semantic.Types
{
    public class BooleanType : BaseType
    {
        public override string ToString()
        {
            return "Boolean";
        }

        public override bool IsAssignable(BaseType otherType)
        {
            throw new NotImplementedException();
        }
    }
}