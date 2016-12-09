using System;
using Lexer;
using Syntax.Parser;
using Syntax.Semantic;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
                //     HandlerFiles file = new HandlerFiles("C:\\Users\\Jimmy Ramos\\Documents\\WebCompilerForC\\code.c");
                HandlerFiles file = new HandlerFiles();

                var code = file.GetCode();

                //  var lex = new Lexer.Lexer(new SourceCode(code));

                //var currentToken = lex.GetNextToken();

                //while (currentToken.TokenType != TokenType.EndOfFile)
                //{
                //    System.Console.WriteLine(currentToken.ToString());
                //    //System.Diagnostics.Debug.WriteLine(currentToken.ToString());

                //    file.WriteCode(currentToken.ToString());

                //    //if (currentToken.TokenType == TokenType.OpBitShiftLeftAndAssignment
                //    //    || currentToken.TokenType == TokenType.OpBitShiftRightAndAssignment)
                //    //{
                //    //    lex.GetNextToken();
                //    //}

                //    currentToken = lex.GetNextToken();

                //    // file.WriteCode(currentToken.Lexeme);
                //}

               var lex = new Lexer.Lexer(new SourceCode(code));

                var parser = new Parser(lex);

               var root = parser.Parse();

               foreach (var statementNode in root)
                {
                    statementNode.ValidateSemantic();
                    Console.WriteLine(statementNode);
                }

                var stack = StackContext.Context.Stack.Peek();

              Console.ReadKey();
            //}
            //catch (Exception e)
            //{
                
            //    Console.WriteLine(e.Message);
            //}

        }
    }
}
