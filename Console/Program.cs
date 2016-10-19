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
            var lex = new Lexer.Lexer(new SourceCode("print 1cont cont1 12 \n" +
                                                     "dos tres 4 6 ;"));
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
