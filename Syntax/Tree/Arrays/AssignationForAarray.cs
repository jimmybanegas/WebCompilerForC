using System;
using System.Collections.Generic;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Declarations;

namespace Syntax.Tree.Arrays
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
