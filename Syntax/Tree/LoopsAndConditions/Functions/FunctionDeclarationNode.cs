using System;
using System.Collections.Generic;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Declarations;

namespace Syntax.Tree.LoopsAndConditions.Functions
{
    public class FunctionDeclarationNode : StatementNode
    {
        public GeneralDeclarationNode Identifier;
        public List<GeneralDeclarationNode> Parameters;
        public List<StatementNode> Sentences;

        public override void ValidateSemantic()
        {
            //throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
