using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.Operators.Binary
{
    public class LessOrEqualOperatorNode : BinaryOperatorNode
    {
        public LessOrEqualOperatorNode()
        {
          
        }

        public override BaseType ValidateSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "<=" + RightOperand.GenerateCode();
        }
    }
}