using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Interpret.TypesValues;
using Syntax.Parser;
using Syntax.Semantic;
using Syntax.Semantic.Types;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            HandlerFiles file = new HandlerFiles();
            var code = file.GetCode();

            var lex = new Lexer.Lexer(new SourceCode(code));

            var parser = new Parser(lex);

            parser.ValidateSemanticServer();

            //parser.Interpret();

            //if (parser.CurrentToken.TokenType == TokenType.HTMLContent)
            //{
            //    Console.WriteLine(parser.CurrentToken.Lexeme);
            //}

               //var root = parser.Parse();

               //foreach (var statementNode in root)
               // {
               //     statementNode.ValidateSemantic();
               //     Console.WriteLine(statementNode);
               // }

             var stack = StackContext.Context.Stack.Peek();

            //foreach (var statementNode in root)
            //{
            //    statementNode.Interpret();
            //}
            var parameters = new List<string> {"10", "20", "Addition"};

            var functiondeclaration = StackContext.Context.FunctionsNodes["operar"];

            StackContext.Context.Stack.Push(StackContext.Context.PastContexts[functiondeclaration.CodeGuid]);

            int pos = 0;
            foreach (var parameter in functiondeclaration.Parameters)
            {
                var typeOfParameter =
                    StackContext.Context.Stack.Peek()
                        .GetVariable(parameter.NameOfVariable.Value, functiondeclaration.Position);

                dynamic value = null;

                if (typeOfParameter is StringType)
                {
                    value = new StringValue { Value = parameters[pos] };
                }
                else if (typeOfParameter is IntType)
                {
                    value = new IntValue { Value = Convert.ToInt32(parameters[pos]) };
                }

               // context.Response.Write($"<h3>\r\nValue : {parameter.NameOfVariable.Value} </h3> ");
           

                StackContext.Context.Stack.Peek().SetVariableValue(parameter.NameOfVariable.Value, value);

                pos++;
            }

            dynamic valueOfResponse = functiondeclaration.Execute();

            dynamic var1 = StackContext.Context.Stack.Peek().GetVariableValue(functiondeclaration.Identifier.NameOfVariable.Value + "ResponseForServer");

            Console.WriteLine(var1.Value);

           // Console.WriteLine(valueOfResponse.Value);

            StackContext.Context.Stack.Pop();

            Console.ReadKey();
      
        }
    }
}
