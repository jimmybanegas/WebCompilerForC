using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syntax.Tree.Nodes.Acessors;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.Declarations
{
    public class GeneralDeclarationNode : StatementNode
    {
        public IdentifierNode DataType;
        public List<PointerNode> ListOfPointer;
        public IdentifierNode NameOfVariable;
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
