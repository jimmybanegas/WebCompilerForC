using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
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
            return StackContext.Context.GetGeneralType("int");
        }

        public override Value Interpret()
        {
            return new IntValue {Value = Value};
        }
    }
}