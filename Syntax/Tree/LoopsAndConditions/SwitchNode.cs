using System;
using System.Collections.Generic;
using Syntax.Exceptions;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.LoopsAndConditions
{
    public class SwitchNode : StatementNode
    {
        public ExpressionNode Expression;
        public List<CaseStatement> CaseStatements;
        public override void ValidateSemantic()
        {
            var conditional = Expression.ValidateSemantic();

            if (!(conditional is BooleanType))
                throw new SemanticException($"A boolean expression was expected, not a {conditional}");

            foreach (var statement in CaseStatements)
            {
                statement.ValidateSemantic();
            }
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
