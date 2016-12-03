using System;

namespace Syntax.Semantic.Types
{
    public class FloatType : BaseType
    {
        public override string ToString()
        {
            return "Float";
        }

        public override bool IsAssignable(BaseType otherType)
        {
            throw new NotImplementedException();
        }
    }
}