﻿using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.LoopsAndConditions.Functions
{
    public class FunctionCallNode : StatementNode
    {
        public IdentifierNode Name;

        public List<ExpressionNode> Parameters;

        public Token Position = new Token();
        public override void ValidateSemantic(Token currentToken)
        {
            var functionType = StackContext.Context.Stack.Peek().GetVariable(Name.Value);

            var o  = functionType as FunctionType;
            if (o != null && o.Parameters.Count != Parameters.Count)
               throw new SemanticException($"You provided {Parameters.Count} parameters, {o.Parameters.Count} are required to call function {Name.Value}");

            int pos = 0;

            foreach (var expression in Parameters)
            {
                var type = expression.ValidateSemantic();

                var typeInTable = o.Parameters[pos].Parameter.DataType.ValidateTypeSemantic();

                if (!(Validations.ValidateReturnTypesEquivalence(type,typeInTable)))
                    throw new SemanticException($"You provided a {type} as parameter, {typeInTable} is required as parameter in position {pos+1}");

                pos++;
            }
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
