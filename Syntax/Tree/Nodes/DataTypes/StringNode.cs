using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.DataTypes
{
    public class StringNode : ExpressionNode
    {
        public string Value { get; set; }
        public override BaseType ValidateSemantic()
        {
            return null;
        }

        public override string GenerateCode()
        {
            return $"\"{Value}\"";
        }
    }
}