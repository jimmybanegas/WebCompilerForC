using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Binary
{
    public class MultiplicationOperatorNode : BinaryOperatorNode
    {

        public MultiplicationOperatorNode()
        {
            
        }

        public override BaseType ValidateSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            return this.LeftOperand.GenerateCode() + "*" + this.RightOperand.GenerateCode();
        }
    }
}