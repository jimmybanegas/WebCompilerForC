using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syntax.Tree.Nodes.BaseNodes;
using Syntax.Tree.Nodes.DataTypes;

namespace Syntax.Tree.Nodes.Declarations
{
    public class EnumItemNode : StatementNode
    {
        public IdentifierNode ItemName;

        public IntegerNode OptionalPosition;
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
