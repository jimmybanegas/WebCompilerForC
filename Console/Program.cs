using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lexer;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = @"print cont cont1 12 
                dos tres 4 6 
                var cuatro 4;;; ;;
                { ] > && != 
                int x = 65;
                bool y = false;
                x = 9 - 12 / (3 + 3) * (2 - 1)";

            var lex = new Lexer.Lexer(new SourceCode(code));

            var currentToken = lex.GetNextToken();

            while (currentToken.TokenType != TokenType.EndOfFile)
            {
                Console.WriteLine(currentToken.ToString());
                currentToken = lex.GetNextToken();
            }

            Console.ReadKey();
        }
    }
}
