namespace Syntax.Interpret.TypesValues
{
    public class BoolValue : Value
    {
        public bool Value;
        public override Value Clone()
        {
            return new BoolValue {Value = Value};
        }
    }
}
