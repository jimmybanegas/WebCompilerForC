using System;
using System.Collections.Generic;
using Syntax.Tree.Acessors;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Identifier
{
    public class IdentifierExpression : ExpressionNode
    {
        public string Value { get; set; }
        public UnaryOperator IncrementOrdecrement { get; set; }
        public List<AccessorNode> Accessors = new List<AccessorNode>();


        public override BaseType ValidateSemantic()
        {
            throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
