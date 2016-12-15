using System;
using System.Collections.Generic;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Tree.Acessors;

namespace Syntax.Semantic.Types
{
    public class StructType : BaseType
    {
        public List<ElementStruct> Elements;
        public StructType(List<ElementStruct> elements)
        {
            Elements = elements;
        }
        public override string ToString()
        {
            return "Struct";
        }

        public override Value GetDefaultValue()
        {
           return new IntValue();
        }

    }
}