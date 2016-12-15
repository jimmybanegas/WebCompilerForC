using System;
using System.Globalization;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.DataTypes
{
    public class BooleanNode : ExpressionNode
    {
        public bool Value { get; set; }
        public override BaseType ValidateSemantic()
        {
           return StackContext.Context.GetGeneralType("bool");
        }

        public override Value Interpret()
        {
           // return Value.ToString(CultureInfo.InvariantCulture); 

            return new BoolValue();
        }
    }
}
