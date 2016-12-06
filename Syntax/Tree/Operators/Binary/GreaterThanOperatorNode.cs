﻿using System;
using System.Collections.Generic;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Binary
{
    public class GreaterThanOperatorNode : BinaryOperatorNode
    {
        public GreaterThanOperatorNode()
        {
            Validation = new Dictionary<Tuple<BaseType, BaseType>, BaseType>
            {
                //{
                //    new Tuple<BaseType, BaseType>(new IntType(), new IntType()), new BooleanType()
                //},
                {
                    new Tuple<BaseType, BaseType>( StackContext.Context.GetGeneralType("int"),
                        StackContext.Context.GetGeneralType("int")),
                    StackContext.Context.GetGeneralType("bool")
                },
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("float"),
                        StackContext.Context.GetGeneralType("float")),
                    StackContext.Context.GetGeneralType("bool")
                },
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("int"),
                        StackContext.Context.GetGeneralType("float")),
                    StackContext.Context.GetGeneralType("bool")
                },
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("float"),
                        StackContext.Context.GetGeneralType("int")),
                    StackContext.Context.GetGeneralType("bool")
                },
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("string"),
                        StackContext.Context.GetGeneralType("string")),
                    StackContext.Context.GetGeneralType("bool")
                },
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("char"),
                        StackContext.Context.GetGeneralType("string")),
                    StackContext.Context.GetGeneralType("bool")
                },
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("string"),
                        StackContext.Context.GetGeneralType("char")),
                    StackContext.Context.GetGeneralType("bool")
                },
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("char"),
                        StackContext.Context.GetGeneralType("char")),
                    StackContext.Context.GetGeneralType("bool")
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

        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + ">" + RightOperand.GenerateCode();
        }
    }
}