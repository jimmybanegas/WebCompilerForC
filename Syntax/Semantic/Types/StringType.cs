﻿using System;

namespace Syntax.Semantic.Types
{
    public class StringType : BaseType
    {
        public override string ToString()
        {
            return "String";
        }

        public override bool IsAssignable(BaseType otherType)
        {
            throw new NotImplementedException();
        }
    }
}