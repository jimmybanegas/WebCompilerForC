using System;
using System.Collections.Generic;
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
                    new Tuple<BaseType, BaseType>(TypesTable.Instance.GetVariable("int"),
                       StackContext.Context.GetGeneralType("int")),
                   StackContext.Context.GetGeneralType("int")
                },
                {
                    new Tuple<BaseType, BaseType>(TypesTable.Instance.GetVariable("float"),
                       StackContext.Context.GetGeneralType("float")),
                   StackContext.Context.GetGeneralType("float")
                },
                {
                    new Tuple<BaseType, BaseType>(TypesTable.Instance.GetVariable("int"),
                       StackContext.Context.GetGeneralType("float")),
                   StackContext.Context.GetGeneralType("float")
                },
                {
                    new Tuple<BaseType, BaseType>(TypesTable.Instance.GetVariable("float"),
                       StackContext.Context.GetGeneralType("int")),
                   StackContext.Context.GetGeneralType("float")
                },
                  {
                    new Tuple<BaseType, BaseType>(TypesTable.Instance.GetVariable("bool"),
                       StackContext.Context.GetGeneralType("bool")),
                   StackContext.Context.GetGeneralType("bool")
                },
                {
                    new Tuple<BaseType, BaseType>(TypesTable.Instance.GetVariable("bool"),
                       StackContext.Context.GetGeneralType("int")),
                   StackContext.Context.GetGeneralType("bool")
                },
                {
                    new Tuple<BaseType, BaseType>(TypesTable.Instance.GetVariable("int"),
                       StackContext.Context.GetGeneralType("bool")),
                   StackContext.Context.GetGeneralType("bool")
                }
            };
        }


        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "/" + RightOperand.GenerateCode();
        }
    }
}