using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.DataTypes
{
    public class BinaryNode : ExpressionNode
    {
        public string Value { get; set; }
        public override BaseType ValidateSemantic()
        {

            return null;
        }

        public override string GenerateCode()
        {
            return Value;
        }
    }
}