using System;
using System.Collections.Generic;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Tree.Acessors;

namespace Syntax.Semantic.Types
{
    public class FloatType : BaseType
    {
        public override string ToString()
        {
            return "Float";
        }

        public override Value GetDefaultValue()
        {
            return new FloatValue {Value = 0};
        }
    }
}