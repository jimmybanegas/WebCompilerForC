using System;
using System.Collections.Generic;
using Syntax.Exceptions;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.LoopsAndConditions
{
    public class ForNode : ForLoopNode
    {
        public ExpressionNode FirstCondition;
        public ExpressionNode SecondCondition;
        public ExpressionNode ThirdCondition;
        public List<StatementNode> Sentences;

        public override void ValidateSemantic()
        {
            var conditional1 = FirstCondition.ValidateSemantic();
            var conditional2 = SecondCondition.ValidateSemantic();
            var conditional3 = ThirdCondition.ValidateSemantic();

            if (!(conditional1 is BooleanType && conditional2 is BooleanType && conditional3 is BooleanType))
                throw new SemanticException($"A boolean expression is expected");

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
