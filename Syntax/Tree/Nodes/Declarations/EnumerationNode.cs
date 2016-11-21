using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree.Nodes.Declarations
{
    public class EnumerationNode : StatementNode
    {
        public IdentifierNode Name;
        public List<TypeOfDeclaration> EnumItems;

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
