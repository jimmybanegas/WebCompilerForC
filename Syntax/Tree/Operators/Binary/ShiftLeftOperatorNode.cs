﻿using System;
using System.Collections.Generic;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Binary
{
    public class ShiftLeftOperatorNode : BinaryOperatorNode
    {
        public ShiftLeftOperatorNode()
        {
            Validation = new Dictionary<Tuple<BaseType, BaseType>, BaseType>
            {
                {
                    new Tuple<BaseType, BaseType>(TypesTable.Instance.GetVariable("int"),
                        TypesTable.Instance.GetVariable("int")),
                    TypesTable.Instance.GetVariable("int")
                },
                {
                    new Tuple<BaseType, BaseType>(TypesTable.Instance.GetVariable("char"),
                        TypesTable.Instance.GetVariable("char")),
                    TypesTable.Instance.GetVariable("int")
                },
                {
                    new Tuple<BaseType, BaseType>(TypesTable.Instance.GetVariable("int"),
                        TypesTable.Instance.GetVariable("char")),
                    TypesTable.Instance.GetVariable("int")
                },
                {
                    new Tuple<BaseType, BaseType>(TypesTable.Instance.GetVariable("char"),
                        TypesTable.Instance.GetVariable("int")),
                    TypesTable.Instance.GetVariable("int")
                }
            };
        }
        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "<<" + RightOperand.GenerateCode();
        }
    }
}
