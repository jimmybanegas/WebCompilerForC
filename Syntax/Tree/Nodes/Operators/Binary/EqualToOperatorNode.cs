using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.Operators.Binary
{
    public class EqualToOperatorNode : BinaryOperatorNode
    {
        public EqualToOperatorNode()
        {
            
        }

        public override BaseType ValidateSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "==" + RightOperand.GenerateCode();
        }
    }
}