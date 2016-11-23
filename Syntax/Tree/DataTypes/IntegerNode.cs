using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.DataTypes
{
    public class IntegerNode : LiteralWithOptionalUnaryOpNode
    {
        public int Value { get; set; }
        public override BaseType ValidateSemantic()
        {
            //return TypesTable.Instance.GetType("integer");
            return null;
        }

        public override string GenerateCode()
        {
            return $"{Value}";
        }
    }
}