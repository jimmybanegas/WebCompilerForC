using System;
using System.Collections.Generic;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Operators.Unary;

namespace Syntax.Tree.Operators.Binary
{
    public class BitwiseOrOperatorNode : BinaryOperatorNode
    {
        public BitwiseOrOperatorNode()
        {
            Validation = new Dictionary<Tuple<BaseType, BaseType>, BaseType>
            {
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("int"),
                        StackContext.Context.GetGeneralType("int")),
                    StackContext.Context.GetGeneralType("int")
                },
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("char"),
                        StackContext.Context.GetGeneralType("char")),
                    StackContext.Context.GetGeneralType("int")
                },
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("int"),
                        StackContext.Context.GetGeneralType("char")),
                    StackContext.Context.GetGeneralType("int")
                },
                {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("char"),
                        StackContext.Context.GetGeneralType("int")),
                    StackContext.Context.GetGeneralType("int")
                }
            };
        }


        public override Value Interpret()
        {
            dynamic left = LeftOperand.Interpret();
            dynamic right = RightOperand.Interpret();

            var unaryNode = LeftOperand is ExpressionUnaryNode;
            if (unaryNode && ((ExpressionUnaryNode)LeftOperand).UnaryOperator is NegativeOperatorNode)
            {
                left.Value = left.Value * -1;
            }

            var unaryNode2 = RightOperand is ExpressionUnaryNode;
            if (unaryNode2 && ((ExpressionUnaryNode)RightOperand).UnaryOperator is NegativeOperatorNode)
            {
                right.Value = right.Value * -1;
            }

            dynamic response = left.Value | right.Value;

            dynamic typeOfReturn = Validations.GetTypeValue(response, response);

            return typeOfReturn;
        }
    }
}
