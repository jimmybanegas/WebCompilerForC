using System;
using System.Globalization;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.DataTypes
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
