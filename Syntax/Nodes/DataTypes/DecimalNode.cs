using System.Globalization;
using Syntax.Tree;

namespace Syntax.Nodes.DataTypes
{
    public class DecimalNode : ExpressionNode
    {
        public double Value { get; set; }

        public override BaseType ValidateSemantic()
        {
            return null;
        }

        public override string GenerateCode()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
}