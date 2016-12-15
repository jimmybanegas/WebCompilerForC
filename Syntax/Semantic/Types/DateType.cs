using System;
using System.Collections.Generic;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Tree.Acessors;

namespace Syntax.Semantic.Types
{
    public class DateType : BaseType
    {
        public override string ToString()
        {
            return "Date";
        }

        public override Value GetDefaultValue()
        {
            return new DateValue {Value = new DateTime()};
        }
    }
}