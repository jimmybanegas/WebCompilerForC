using System;
using System.Collections.Generic;
using Syntax.Exceptions;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.LoopsAndConditions
{
    public class DoWhileNode : StatementNode
    {
        public ExpressionNode WhileCondition;
        public List<StatementNode> Sentences;

        public override void ValidateSemantic()
        {
            var conditional = WhileCondition.ValidateSemantic();

            if (!(conditional is BooleanType))
                throw new SemanticException($"A boolean expression was expected, not a {conditional}");

            foreach (var statement in Sentences)
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
