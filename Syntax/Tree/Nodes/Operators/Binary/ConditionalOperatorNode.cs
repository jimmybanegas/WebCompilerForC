﻿using System;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.Operators.Binary
{
    public class ConditionalOperatorNode : BinaryOperatorNode
    {
        public ConditionalOperatorNode()
        {
        }

        public override BaseType ValidateSemantic()
        {
            throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "?" + RightOperand.GenerateCode();
        }
    }
}