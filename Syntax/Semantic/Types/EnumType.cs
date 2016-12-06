using System;
using System.Collections.Generic;

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

        public List<ElementEnum> Elements;

        public EnumType(List<ElementEnum> elements)
        {
            Elements = elements;
        }
    }
}