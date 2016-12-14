using System;
using System.Globalization;
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

        public override string Interpret()
        {
            return Value.ToString(CultureInfo.InvariantCulture); ;
        }
    }
}
