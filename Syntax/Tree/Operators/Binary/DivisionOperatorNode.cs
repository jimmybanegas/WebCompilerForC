using System;
using System.Collections.Generic;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Binary
{
    public class DivisionOperatorNode : BinaryOperatorNode
    {
        public DivisionOperatorNode()
        {
            Validation = new Dictionary<Tuple<BaseType, BaseType>, BaseType>
            {
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("int"),
                       StackContext.Context.GetGeneralType("int")),
                   StackContext.Context.GetGeneralType("int")
                },
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("float"),
                       StackContext.Context.GetGeneralType("float")),
                   StackContext.Context.GetGeneralType("float")
                },
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("int"),
                       StackContext.Context.GetGeneralType("float")),
                   StackContext.Context.GetGeneralType("float")
                },
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("float"),
                       StackContext.Context.GetGeneralType("int")),
                   StackContext.Context.GetGeneralType("float")
                },
                  {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("bool"),
                       StackContext.Context.GetGeneralType("bool")),
                   StackContext.Context.GetGeneralType("bool")
                },
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("bool"),
                       StackContext.Context.GetGeneralType("int")),
                   StackContext.Context.GetGeneralType("bool")
                },
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("int"),
                       StackContext.Context.GetGeneralType("bool")),
                   StackContext.Context.GetGeneralType("bool")
                }
            };
        }


        public override Value Interpret()
        {
            dynamic response = LeftOperand.Interpret() + "/" + RightOperand.Interpret();

            return new BoolValue { Value = response.Value };
        }
    }
}