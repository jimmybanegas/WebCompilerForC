using System;
using System.Collections.Generic;
using Syntax.Exceptions;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.Identifier;
using Syntax.Tree.Operators.Unary;

namespace Syntax.Tree.BaseNodes
{
    public abstract class BinaryOperatorNode : ExpressionNode
    {
        public string Value;

        public ExpressionNode RightOperand; 
        public ExpressionNode LeftOperand;
        public Dictionary<Tuple<BaseType, BaseType>, BaseType> Validation;

        public override BaseType ValidateSemantic()
        {
            var leftType = LeftOperand.ValidateSemantic();
            var rightType = RightOperand.ValidateSemantic();

            if (leftType is EnumType && rightType is EnumType)
            {
                var nameOfAssignedValue = ((IdentifierExpression) ((ExpressionUnaryNode) RightOperand).Factor).Name;
                foreach (var element in (leftType as EnumType).Elements)
                {
                    if (element.Element.ItemName.Value == nameOfAssignedValue)
                    {
                        return new BooleanType();
                    }
                }
                return new BooleanType();
                //  return leftType;
            }          

            BaseType result;

            if (Validation.TryGetValue(new Tuple<BaseType, BaseType>(leftType, rightType), out result))
            {
                return result;
            }

            throw new SemanticException($"You can't operate two varibles of different types: {leftType} and {rightType} at Row: {Position.Row} , Column {Position.Column}");
        }

    }
}