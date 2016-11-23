using System;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.DataTypes
{
    public class OctalNode : ExpressionNode
    {
        public string Value { get; set; }
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
