using System;
using Syntax.Exceptions;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

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

            dynamic response = left.Value = right.Value;

            dynamic typeOfReturn = Validations.GetTypeValue(response, response);

            return typeOfReturn;
        }
    }
}
