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

        public Token Position = new Token();
        public override void ValidateSemantic(Token currentToken)
        {
           // ItemName.ValidateSemantic(Position);

            var type = OptionalPosition.ValidateSemantic();

            if (!(type is IntType))
            {
                throw new SemanticException("An integer type was expected");
            }
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
