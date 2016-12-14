namespace Syntax.Interpret.TypesValues
{
    public class StringValue : Value
    {
        public string Value;
        public override Value Clone()
        {
            return new StringValue { Value = Value};
        }
    }
}
