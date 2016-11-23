using System;
using System.Globalization;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.DataTypes
{
    public class BooleanNode : ExpressionNode
    {
        public bool Value { get; set; }
        public override BaseType ValidateSemantic()
        {
            throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            return Value.ToString(CultureInfo.InvariantCulture); ;
        }
    }
}
