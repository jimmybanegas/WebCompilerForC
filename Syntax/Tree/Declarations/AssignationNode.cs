using System;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.Declarations
{
    public class AssignationNode : StatementNode
    {
        public IdentifierNode LeftValue { get; set; }
        public ExpressionNode RightValue { get; set; }

        public override void ValidateSemantic()
        {
            var rTipo = RightValue.ValidateSemantic();

            if (!TypesTable.Instance.VariableExist(LeftValue.Value))
                TypesTable.Instance.RegisterType(LeftValue.Value, rTipo);
            else
            {
                var lTipo = TypesTable.Instance.GetVariable(LeftValue.Value);
                if (lTipo.GetType() != rTipo.GetType())
                    throw new SemanticException($"No se puede asignar {rTipo} a {lTipo}");
            }
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
