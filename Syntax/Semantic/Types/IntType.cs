using System;
using System.Collections.Generic;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Tree.Acessors;

namespace Syntax.Semantic.Types
{
    public class IntType : BaseType
    {
        public override string ToString()
        {
            return "Int";
        }

        public override Value GetDefaultValue()
        {
            return new IntValue {Value = 0};
        }
    }
}