using System.Globalization;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.DataTypes
{
    public class DecimalNode : LiteralWithOptionalUnaryOpNode
    {
        public decimal Value { get; set; }

        public override BaseType ValidateSemantic()
        {
            return StackContext.Context.GetGeneralType("float");
        }

        public override Value Interpret()
        {
            return new FloatValue { Value = (float) Value};
        }
    }
}