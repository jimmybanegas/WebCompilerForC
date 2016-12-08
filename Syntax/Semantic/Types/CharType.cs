using System;
using System.Collections.Generic;
using Syntax.Tree.Acessors;

namespace Syntax.Semantic.Types
{
    public class CharType : BaseType
    {
        public override string ToString()
        {
            return "Char";
        }

        public override bool IsAssignable(BaseType otherType)
        {
            throw new NotImplementedException();
        }
    }
}