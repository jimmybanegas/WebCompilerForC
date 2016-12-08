using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.Acessors;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Declarations;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.DataTypes
{
    public class ConstantNode : StatementNode
    {
        public IdentifierNode ConstName;
        public List<PointerNode> PointersList;
        public IdentifierNode TypeOfConst;
        //public ExpressionNode ExpressionConst;
        public AssignationNode Assignation;

        public Token Position;
        public override void ValidateSemantic(Token currentToken)
        {
            var type = TypeOfConst.ValidateTypeSemantic();

            if (Assignation != null)
            {
                Assignation.LeftValue = TypeOfConst;

                Assignation.ValidateSemantic(Position);
            }

            var variable = new TypesTable.Variable
            {
                Accessors = ConstName.Accessors,
                Pointers = PointersList
            };

            StackContext.Context.Stack.Peek().Table.Remove(ConstName.Value);

            StackContext.Context.Stack.Peek().RegisterType(ConstName.Value, new ConstType
            {
                Assignation = Assignation, Type = type
            }, Position,variable);
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
