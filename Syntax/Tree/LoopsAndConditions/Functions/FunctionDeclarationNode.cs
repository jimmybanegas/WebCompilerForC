using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.DataTypes;
using Syntax.Tree.Declarations;
using Syntax.Tree.GeneralSentences;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.LoopsAndConditions.Functions
{
    public class FunctionDeclarationNode : StatementNode
    {
        public GeneralDeclarationNode Identifier;
        public List<GeneralDeclarationNode> Parameters;
        public List<StatementNode> Sentences;

        public Token Position = new Token();

        public override void ValidateSemantic(Token currentToken)
        {
            StackContext.Context.Stack.Push(new TypesTable());

            List<ParameterFunction> listParams = new List<ParameterFunction>();
            BaseType returnType = null;

            foreach (var parameter in Parameters)
            {
                parameter.ValidateSemantic(Position);

               listParams.Add(new ParameterFunction { Parameter = parameter} ); 
            }

            foreach (var sentence in Sentences)
            {
                if (sentence is ReturnStatementNode)
                {
                    var typeOfReturn = (sentence as ReturnStatementNode).ValidateSemanticAndGetType();

                    returnType = Identifier.DataType.ValidateTypeSemantic();

                    var canReturn = Validations.ValidateReturnTypesEquivalence(typeOfReturn, returnType);

                    if (!canReturn)
                    {
                        throw new SemanticException($"Return types don't match at function {Identifier.NameOfVariable.Value}");
                    }
                }
                else
                {
                    sentence.ValidateSemantic(Position);
                }
            }

            var variable = new TypesTable.Variable
            {
                Accessors = Identifier.NameOfVariable.Accessors,
                Pointers = Identifier.ListOfPointer
            };

            StackContext.Context.Stack.Pop();

            StackContext.Context.Stack.Peek().RegisterType(Identifier.NameOfVariable.Value, new FunctionType(listParams,returnType),currentToken,variable);
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
