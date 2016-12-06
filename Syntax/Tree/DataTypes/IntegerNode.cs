using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.DataTypes
{
    public class IntegerNode : LiteralWithOptionalUnaryOpNode
    {
        public int Value { get; set; }
        public override BaseType ValidateSemantic()
        {
            //  return new IntType();
            return TypesTable.Instance.GetVariable("int");
        }

        public override string GenerateCode()
        {
            return $"{Value}";
        }
    }
}