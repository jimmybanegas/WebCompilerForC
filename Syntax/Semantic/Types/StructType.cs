using System;
using System.Collections.Generic;
using Syntax.Tree.Acessors;

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

        public List<ElementStruct> Elements;
      
        public StructType(List<ElementStruct> elements)
        {
            Elements = elements;
        }

    }
}