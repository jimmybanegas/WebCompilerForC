using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Binary
{
    public class AdditionOperatorNode : BinaryOperatorNode
    {

        public AdditionOperatorNode()
        {
        }

      
        public override BaseType ValidateSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "+" + RightOperand.GenerateCode();
        }
    }
}