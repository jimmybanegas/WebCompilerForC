using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.Operators.Binary
{
    public class DivisionOperatorNode : BinaryOperatorNode
    {
        public DivisionOperatorNode()
        {

        }

        public override BaseType ValidateSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "/" + RightOperand.GenerateCode();
        }
    }
}