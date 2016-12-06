using System;

namespace Syntax.Semantic.Types
{
    public class IntType : BaseType
    {
        public override string ToString()
        {
            return "Int";
        }

        public override bool IsAssignable(BaseType otherType)
        {
            throw new NotImplementedException();
        }
       
    }
}