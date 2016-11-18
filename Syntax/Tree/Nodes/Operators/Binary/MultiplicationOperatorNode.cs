using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.Operators.Binary
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