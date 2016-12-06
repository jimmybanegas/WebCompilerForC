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
            // return new BooleanType();
            return TypesTable.Instance.GetVariable("bool");
        }

        public override string GenerateCode()
        {
            return Value.ToString(CultureInfo.InvariantCulture); ;
        }
    }
}
