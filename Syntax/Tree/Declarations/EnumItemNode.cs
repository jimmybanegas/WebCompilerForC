using System;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic.Types;
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
           // ItemName.ValidateSemantic(Position);

            var type = OptionalPosition.ValidateSemantic();

            if (!(type is IntType))
            {
                throw new SemanticException($"An integer type was expected at Row: {Position.Row} , Column {Position.Column}");
            }
        }

        public override string Interpret()
        {
            throw new NotImplementedException();
        }
    }
}
