using System;
using Lexer;
using Syntax;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
          
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

            parser.Parse();

            Console.ReadKey();

        }
    }
}
