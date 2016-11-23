using System;
using System.Collections.Generic;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.Struct
{
    public  class StructNode : StatementNode
    {
        public IdentifierExpression Name;
        public List<StructItemNode> ListOfItems;
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
