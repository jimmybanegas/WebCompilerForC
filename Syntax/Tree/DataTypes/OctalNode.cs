using System;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.DataTypes
{
    public class OctalNode : ExpressionNode
    {
        public string Value { get; set; }
        public override BaseType ValidateSemantic()
        {
          return StackContext.Context.GetGeneralType("int");
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
