using System;
using System.Collections.Generic;
using System.Linq;
using Lexer;
using Syntax.Exceptions;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.DataTypes;
using Syntax.Tree.Declarations;
using Syntax.Tree.GeneralSentences;
using Syntax.Tree.Identifier;
using Syntax.Tree.Operators.Unary;

namespace Syntax.Tree.LoopsAndConditions.Functions
{
    public class FunctionDeclarationNode : StatementNode
    {
        public GeneralDeclarationNode Identifier;
        public List<GeneralDeclarationNode> Parameters;
        public List<StatementNode> Sentences;

        public override void ValidateSemantic()
        {
            StackContext.Context.Stack.Push(new TypesTable());
            
            List<ParameterFunction> listParams = new List<ParameterFunction>();
            BaseType returnType = null;


            var variable = new TypesTable.Variable
            {
                Accessors = Identifier.NameOfVariable.Accessors,
                Pointers = Identifier.ListOfPointer
            };
            StackContext.Context.Stack.Peek().RegisterType(Identifier.NameOfVariable.Value, new FunctionType(listParams, returnType), Identifier.Position, variable);
            foreach (var parameter in Parameters)
            {
                parameter.ValidateSemantic();

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
                        throw new SemanticException($"Return types don't match at function {Identifier.NameOfVariable.Value} at Row: {Position.Row} , Column {Position.Column}");
                    }
                }
                else
                {
                    sentence.ValidateSemantic();
                }
            }

          

            StackContext.Context.PastContexts.Add(CodeGuid, StackContext.Context.Stack.Pop());

            StackContext.Context.Stack.Peek().RegisterType(Identifier.NameOfVariable.Value, new FunctionType(listParams,returnType), Identifier.Position, variable);
            StackContext.Context.Stack.First().RegisterType(Identifier.NameOfVariable.Value+"ResponseForServer", new IntType(), Position, variable);
        }

        public override void Interpret()
        {
            StackContext.Context.Stack.Push(StackContext.Context.PastContexts[CodeGuid]);

            StackContext.Context.FunctionsNodes.Add(Identifier.NameOfVariable.Value, this);

            //StackContext.Context.PastContexts.Remove(CodeGuid);
            StackContext.Context.Stack.Pop();
        }

        public Value Execute()
        {
            dynamic returnValue = null;

            foreach (var sentence in Sentences)
            {
                if (sentence is ReturnStatementNode)
                {
                    returnValue = (sentence as ReturnStatementNode).GetValueOfReturn();
                }
                sentence.Interpret();
            }

            StackContext.Context.Stack.First().SetVariableValue(Identifier.NameOfVariable.Value+ "ResponseForServer",returnValue);
            
            return returnValue;
        }
    }
}
