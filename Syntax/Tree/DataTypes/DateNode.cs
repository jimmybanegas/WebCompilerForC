using System;
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

            int year = Convert.ToInt32(Value.Substring(6, 4));
            int month = Convert.ToInt32(Value.Substring(3, 2));
            int day = Convert.ToInt32(Value.Substring(0, 2));

            return new DateValue { Value = new DateTime(year, month, day)};
        }
    }
}