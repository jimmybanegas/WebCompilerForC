using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.Operators.Binary
{
    public class SubstractionOperatorNode : BinaryOperatorNode
    {
        public SubstractionOperatorNode()
        {

        }

        public override BaseType ValidateSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "-" + RightOperand.GenerateCode();
        }
    }
}