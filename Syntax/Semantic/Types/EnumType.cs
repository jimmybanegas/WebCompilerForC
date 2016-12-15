using System;
using System.Collections.Generic;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;

namespace Syntax.Semantic.Types
{
    public class EnumType : BaseType
    {
        public override string ToString()
        {
            return "Enum";
        }

        public override Value GetDefaultValue()
        {
           return new IntValue();
        }


        public List<ElementEnum> Elements;

        public EnumType(List<ElementEnum> elements)
        {
            Elements = elements;
        }
    }
}