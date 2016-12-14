namespace Syntax.Interpret.TypesValues
{
    public class CharValue : Value
    {
        public char Value;
        public override Value Clone()
        {
            return new CharValue {Value = Value};
        }
    }
}
