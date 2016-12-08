using System;
using System.Collections.Generic;
using Syntax.Tree.Acessors;

namespace Syntax.Semantic.Types
{
    public class DateType : BaseType
    {
        public override string ToString()
        {
            return "Date";
        }

        public override bool IsAssignable(BaseType otherType)
        {
            throw new NotImplementedException();
        }
    }
}