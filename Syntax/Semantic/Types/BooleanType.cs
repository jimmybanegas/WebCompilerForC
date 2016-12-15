using System;
using System.Collections.Generic;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Tree.Acessors;

namespace Syntax.Semantic.Types
{
    public class BooleanType : BaseType
    {
        public override string ToString()
        {
            return "Boolean";
        }

        public override Value GetDefaultValue()
        {
            return new BoolValue {Value = false};
        }

      
    }
}