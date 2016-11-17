using Syntax.Tree;

namespace Syntax.Nodes.Operators
{
    public class NotOperatorNode : ExpressionNode
    {
        public override BaseType ValidateSemantic()
        {
            return null;
        }

        public override string GenerateCode()
        {
            return "!";
        }
    }
}