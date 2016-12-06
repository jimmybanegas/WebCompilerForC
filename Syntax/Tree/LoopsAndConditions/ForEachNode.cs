using System.Collections.Generic;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.LoopsAndConditions
{
    public class ForEachNode : ForLoopNode
    {
        public IdentifierNode DataType;
        public IdentifierNode Item;
        public IdentifierNode List;

        public List<StatementNode> Sentences;

        public override void ValidateSemantic()
        {
            var type=DataType.ValidateTypeSemantic();

            TypesTable.Instance.RegisterType(Item.Value,type);

          //  TypesTable.Instance.RegisterType(List.Value, type);

        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}
