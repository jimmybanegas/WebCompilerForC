using System;
using System.Collections.Generic;
using Syntax.Exceptions;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.LoopsAndConditions
{
    public class IfNode : StatementNode
    {
        public ExpressionNode IfCondition;
        public List<StatementNode> TrueBlock;
        public List<StatementNode> FalseBlock;

        public override void ValidateSemantic()
        {
            var condition = IfCondition.ValidateSemantic();

            if (!(condition is BooleanType))
                throw new SemanticException("A boolean expression was expected");

            foreach (var statement in TrueBlock)
            {
                statement.ValidateSemantic();
            }

            foreach (var statementNode in FalseBlock)
            {
                statementNode.ValidateSemantic();
            }
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
