using System;
using System.Web;
using System.Web.Hosting;
using Lexer;
using Syntax;
using Syntax.Parser;

namespace Server
{
    public class Handler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            HandlerFiles file = new HandlerFiles();
            var code = file.GetCode();
        
            var lex = new Lexer.Lexer(new SourceCode(code));

            var parser = new Parser(lex);

            try
            {
                parser.Parse();
                context.Response.Write($"{code}");
            }
            catch (Exception exception)
            {
                context.Response.Write($"<h3>{exception.Message}</h3>");
            }

        }

        public bool IsReusable { get; }
    }
}
