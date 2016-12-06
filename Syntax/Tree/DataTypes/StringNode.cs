using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.DataTypes
{
    public class StringNode : ExpressionNode
    {
        public string Value { get; set; }
        public override BaseType ValidateSemantic()
        {
            // return new StringType();
            //return TypesTable.Instance.GetVariable("string");
            return StackContext.Context.GetGeneralType("string");
        }

        public override string GenerateCode()
        {
            return $"\"{Value}\"";
        }
    }
}