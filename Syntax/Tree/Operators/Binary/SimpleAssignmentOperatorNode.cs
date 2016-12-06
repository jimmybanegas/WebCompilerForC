using System;
using Syntax.Exceptions;
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

            //if (rTipo == lTipo)
            //{
            //    return lTipo;
            //}

            if (Validations.ValidateReturnTypesEquivalence(rTipo,lTipo))
            {
                return rTipo;
            }

           throw new SemanticException($"Types don't match {rTipo} and {lTipo}");
        }

        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "=" + RightOperand.GenerateCode();
        }
    }
}
