using System;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.DataTypes
{
    public class BinaryNode : ExpressionNode
    {
        public string Value;
        public override BaseType ValidateSemantic()
        {

            return null;
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}