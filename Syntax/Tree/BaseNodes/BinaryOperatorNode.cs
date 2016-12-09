using System;
using System.Collections.Generic;
using Syntax.Exceptions;
using Syntax.Semantic;

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

            BaseType result;

            if (Validation.TryGetValue(new Tuple<BaseType, BaseType>(leftType, rightType), out result))
            {
                return result;
            }

            throw new SemanticException($"You can't operate two varibles of different types: {leftType} and {rightType} at Row: {Position.Row} , Column {Position.Column}");
        }

    }
}