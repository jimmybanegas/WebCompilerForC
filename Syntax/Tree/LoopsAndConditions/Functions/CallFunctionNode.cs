using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.LoopsAndConditions.Functions
{
    public class CallFunctionNode : ExpressionNode
    {
        public string Name;
        public List<ExpressionNode> ListOfExpressions;

        public Token Position = new Token();
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
