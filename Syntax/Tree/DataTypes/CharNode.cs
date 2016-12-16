using System;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.DataTypes
{
    class CharNode : ExpressionNode
    {
        public string Value { get; set; }
        public override BaseType ValidateSemantic()
        {
          return StackContext.Context.GetGeneralType("char");
        }

        public override Value Interpret()
        {
            return new CharValue {Value = Convert.ToChar(Value)};
        }
    }
}
