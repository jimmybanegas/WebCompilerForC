﻿using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Declarations;

namespace Syntax.Tree.Arrays
{
    public class AssignationForArray : AssignationNode
    {
        public new List<ExpressionNode> RightValue { get; set; }
        public override void ValidateSemantic(Token currentToken)
        {

            foreach (var expressionNode in RightValue)
            {
                var rTipo = expressionNode.ValidateSemantic();

                if (!StackContext.Context.Stack.Peek().VariableExist(LeftValue.Value))
                    StackContext.Context.Stack.Peek().RegisterType(LeftValue.Value, rTipo,currentToken);
                else
                {
                    var lTipo = StackContext.Context.Stack.Peek().GetVariable(LeftValue.Value);
                    if (lTipo.GetType() != rTipo.GetType())
                        throw new SemanticException($"You can't assign a {rTipo} to a {lTipo}");
                }
            }
          
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}