using System;
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
            throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
