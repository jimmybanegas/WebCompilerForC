using System;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.DataTypes
{
    public class HexadecimalNode : ExpressionNode
    {
        public string Value { get; set; }


        public override BaseType ValidateSemantic()
        {
          return StackContext.Context.GetGeneralType("int");
        }

        public override Value Interpret()
        {
           // return Value;

            return new IntValue();
        }
    }
}