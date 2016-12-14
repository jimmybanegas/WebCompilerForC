namespace Syntax.Interpret.TypesValues
{
    public class IntValue : Value
    {
        public int Value;
        public override Value Clone()
        {
            return new IntValue {Value = Value};
        }
    }
}
