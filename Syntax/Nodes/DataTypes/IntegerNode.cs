using Syntax.Tree;

namespace Syntax.Nodes.DataTypes
{
    public class IntegerNode : ExpressionNode
    {

        public float Value { get; set; }
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