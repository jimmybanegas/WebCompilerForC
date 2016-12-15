using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.DataTypes
{
    public class DateNode : ExpressionNode
    {
        public string Value { get; set; }

        public override BaseType ValidateSemantic()
        {
           return StackContext.Context.GetGeneralType("date");
        }

        public override Value Interpret()
        {
           // return $"#{Value}#";

            return new DateValue();
        }
    }
}