using System;
using Syntax.Tree;

namespace Syntax.Nodes.DataTypes
{
    public class HexadecimalNode : ExpressionNode
    {
        public string Value;


        public override BaseType ValidateSemantic()
        {
            throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}