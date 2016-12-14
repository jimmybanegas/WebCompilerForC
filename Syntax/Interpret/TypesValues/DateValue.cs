using System;

namespace Syntax.Interpret.TypesValues
{
    public class DateValue : Value
    {
        public DateTime Value;
        public override Value Clone()
        {
            return new DateValue {Value = Value};
        }
    }
}
