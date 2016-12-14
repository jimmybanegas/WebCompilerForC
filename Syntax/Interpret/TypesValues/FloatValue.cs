namespace Syntax.Interpret.TypesValues
{
    public class FloatValue : Value
    {
        public float Value;
        public override Value Clone()
        {
            return new FloatValue {Value = Value};
        }
    }
}
