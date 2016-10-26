using Lexer;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
          
           // HandlerFiles file = new HandlerFiles("C:\\Users\\Jimmy Ramos\\Documents\\WebCompilerForC\\code.c");
            HandlerFiles file = new HandlerFiles();

           // System.Console.WriteLine(file._defaultPath);

         //   string cadena = "This\nis\na\ntest\n\nShe said, \"How are you?\n";

        //    System.Console.WriteLine(cadena);

            var code = file.GetCode();

            /*var code = @"print cont cont1 12 
                dos tres 4 6 
                var cuatro 4;;; ;;
                { ] > && != 
                int x = 65;
                bool y = false;
                string c = ""prueba de cadena"";
                x=9-12/(3+3)*(2-1)";

            code = Regex.Replace(code, @"[\r\t]+", "");*/

            //System.Console.WriteLine(code);

            var lex = new Lexer.Lexer(new SourceCode(code));

            var currentToken = lex.GetNextToken();

            while (currentToken.TokenType != TokenType.EndOfFile)
            {
                  System.Console.WriteLine(currentToken.ToString());
                //System.Diagnostics.Debug.WriteLine(currentToken.ToString());
              
                file.WriteCode(currentToken.ToString());
                currentToken = lex.GetNextToken();

               // file.WriteCode(currentToken.Lexeme);
            }

            System.Console.ReadKey();
        }
    }
}
