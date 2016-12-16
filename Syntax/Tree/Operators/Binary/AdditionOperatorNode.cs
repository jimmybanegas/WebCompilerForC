﻿using System;
using System.Collections.Generic;
using System.Text;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Binary
{
    public class AdditionOperatorNode : BinaryOperatorNode
    {
        public AdditionOperatorNode()
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
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("char"),
                        StackContext.Context.GetGeneralType("char")),
                    StackContext.Context.GetGeneralType("string")
                },
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("string"),
                        StackContext.Context.GetGeneralType("string")),
                    StackContext.Context.GetGeneralType("string")
                },
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("char"),
                        StackContext.Context.GetGeneralType("string")),
                    StackContext.Context.GetGeneralType("string")
                },
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("string"),
                        StackContext.Context.GetGeneralType("char")),
                    StackContext.Context.GetGeneralType("string")
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
            dynamic left = LeftOperand.Interpret();
            dynamic right = RightOperand.Interpret();

            dynamic response = left.Value + right.Value;

            dynamic typeOfReturn;

            if (left is CharValue && right is CharValue)
            {
                typeOfReturn = Validations.GetTypeValue(new StringValue(), left.Value.ToString() + right.Value.ToString());
            }
            else
            {
                typeOfReturn = Validations.GetTypeValue(left, response);
            }

            return typeOfReturn;
        }
    }
}