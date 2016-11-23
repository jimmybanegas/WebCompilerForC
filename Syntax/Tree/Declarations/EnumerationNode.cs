using System;
using System.Collections.Generic;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.Declarations
{
    public class EnumerationNode : StatementNode
    {
        public IdentifierNode Name;
        //public List<TypeOfDeclaration> EnumItems;
        public List<StatementNode> EnumItems;

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
