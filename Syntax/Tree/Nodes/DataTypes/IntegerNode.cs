using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.DataTypes
{
    public class IntegerNode : ExpressionNode
    {
        public string Value { get; set; }
        public override BaseType ValidateSemantic()
        {
            //return TypesTable.Instance.GetType("integer");
            return null;
        }

        public override string GenerateCode()
        {
            return $"{Value}";
        }
    }
}