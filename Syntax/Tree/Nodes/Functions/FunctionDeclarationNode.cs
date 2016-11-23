using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syntax.Tree.Nodes.BaseNodes;
using Syntax.Tree.Nodes.Declarations;

namespace Syntax.Tree.Nodes.Functions
{
    public class FunctionDeclarationNode : StatementNode
    {
        public GeneralDeclarationNode Identifier;
        public List<GeneralDeclarationNode> Parameters;
        public List<StatementNode> Sentences;

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
