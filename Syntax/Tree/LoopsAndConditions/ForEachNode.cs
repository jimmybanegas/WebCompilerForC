using System.Collections.Generic;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.LoopsAndConditions
{
    public class ForEachNode : ForLoopNode
    {
        //Declaration
        public IdentifierNode DataType;
        public IdentifierNode Item;
        public IdentifierNode List;

        public List<StatementNode> Sentences;

        public override void ValidateSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}
