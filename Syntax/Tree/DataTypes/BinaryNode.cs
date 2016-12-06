using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.DataTypes
{
    public class BinaryNode : ExpressionNode
    {
        public string Value { get; set; }
        public override BaseType ValidateSemantic()
        {
            // return new IntType();
            // return StackContext.Context.Stack.Peek().GetVariable("int");
            return StackContext.Context.GetGeneralType("int");
        }

        public override string GenerateCode()
        {
            return Value;
        }
    }
}