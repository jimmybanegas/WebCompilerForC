using System;

namespace Syntax.Semantic.Types
{
    public class ConstType : BaseType
    {
        public override string ToString()
        {
            return "Const";
        }

        public override bool IsAssignable(BaseType otherType)
        {
            throw new NotImplementedException();
        }
    }
}