using System;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.DataTypes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.Declarations
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
