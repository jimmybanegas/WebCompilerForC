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

            //if (!TypesTable.Instance.VariableExist(LeftOperand.))
            //    TypesTable.Instance.RegisterType(LeftValue.Value, rTipo);
            //else
            //{
            //    var lTipo = TypesTable.Instance.GetVariable(LeftValue.Value);
            //    if (lTipo.GetType() != rTipo.GetType())
            //        throw new SemanticException($"No se puede asignar {rTipo} a {lTipo}");
            //}

            //if (Equals(rTipo,lTipo))
            //{
            //    return lTipo;
            //}
            

            if (rTipo == lTipo)
            {
                return lTipo;
            }

           throw new SemanticException($"Types don't match {rTipo} and {lTipo}");
        }

        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "=" + RightOperand.GenerateCode();
        }
    }
}
