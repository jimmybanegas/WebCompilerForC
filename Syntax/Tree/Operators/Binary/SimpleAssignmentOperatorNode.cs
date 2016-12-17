using System;
using Syntax.Exceptions;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Operators.Unary;

namespace Syntax.Tree.Operators.Binary
{
    class SimpleAssignmentOperatorNode : BinaryOperatorNode
    {
        public override BaseType ValidateSemantic()
        {
            var rTipo = RightOperand.ValidateSemantic();

            var lTipo = LeftOperand.ValidateSemantic();        

            if (Validations.ValidateReturnTypesEquivalence(rTipo,lTipo))
            {
                return rTipo;
            }

           throw new SemanticException($"Types don't match {rTipo} and {lTipo} at Row: {Position.Row}, Column: {Position.Column}");
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

            dynamic response = left.Value = right.Value;

            dynamic typeOfReturn = Validations.GetTypeValue(response, response);

            return typeOfReturn;
        }
    }
}
