using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lexer;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Declarations;

namespace Syntax.Tree.Struct
{
    public class StructDeclaration : StatementNode
    {
        public GeneralDeclarationNode General;

        public List<ExpressionNode> Initialization;

        public override void ValidateSemantic(Token currentToken)
        {
            General.ValidateSemantic(currentToken);

            if (Initialization != null)
            {
                foreach (var node in Initialization)
                {
                    node.ValidateSemantic();
                }
            }
          
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
