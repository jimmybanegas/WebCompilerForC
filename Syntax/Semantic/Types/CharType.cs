using System;
using System.Collections.Generic;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Tree.Acessors;

namespace Syntax.Semantic.Types
{
    public class CharType : BaseType
    {
        public override string ToString()
        {
            return "Char";
        }

        public override Value GetDefaultValue()
        {
            return new CharValue {Value = ' '};
        }
    }
}