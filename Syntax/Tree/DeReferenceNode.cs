using System;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree
{
    public class DeReferenceNode : StatementNode
    {
        //Para  suma (int &entrada)
        public string Value;
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