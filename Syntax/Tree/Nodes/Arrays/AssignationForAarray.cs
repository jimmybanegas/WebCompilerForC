using System;
using System.Collections.Generic;
using Syntax.Tree.Nodes.BaseNodes;
using Syntax.Tree.Nodes.Declarations;

namespace Syntax.Tree.Nodes.Arrays
{
    public class AssignationForAarray : AssignationNode
    {
        public new List<ExpressionNode> RightValue { get; set; }
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
