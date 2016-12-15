using System;
using System.Collections.Generic;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Tree.Acessors;

namespace Syntax.Semantic.Types
{
    public class StringType : BaseType
    {
        public override string ToString()
        {
            return "String";
        }

        public override Value GetDefaultValue()
        {
            return new StringValue {Value = ""};
        }
    }
}