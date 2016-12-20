using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Hosting;
using Lexer;
using Syntax;
using Syntax.Interpret.TypesValues;
using Syntax.Parser;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.Acessors;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;
using Syntax.Tree.Operators.Unary;

namespace Server
{
    public class Handler : IHttpHandler
    {
        private bool _semanticIsValidated;
        public void ProcessRequest(HttpContext context)
        {
            var file = new HandlerFiles();
            var code = file.GetCode();
        
            var lex = new Lexer.Lexer(new SourceCode(code));

            var parser = new Parser(lex);

            if (parser.CurrentToken.TokenType == TokenType.HTMLContent)
            {
                context.Response.Write(parser.CurrentToken.Lexeme);
            }

            var parameters = new List<string>();

            try
            {
                string[] keys = context.Request.Form.AllKeys;

                if (keys.Length > 0)
                {
                    foreach (string key in HttpContext.Current.Request.Form.AllKeys)
                    {
                        string value = HttpContext.Current.Request.Form[key];

                        //context.Response.Write($"key : {key}, Value: {value} \n");

                        int number;
                        bool result = int.TryParse(value,out number);

                        if (!result)
                        {
                            value = "\"" + value + "\"";
                        }

                        parameters.Add(value);
                    }

                    //string csvString = string.Join(",", myValues);

                    //string newValue = "int respuesta = operar(" + csvString + ");";

                //    context.Response.Write(newValue);

                    //var replace2 = "";
                    //if (lex.SourceCode._sourceCode.Contains("int respuesta = operar();"))
                    //{
                    //  //  var replace = parser.Lexer.SourceCode._sourceCode.Replace("int respuesta = operar();", newValue);
                    //     replace2 = lex.SourceCode._sourceCode.Replace("int respuesta = operar();", newValue);
                    //}

                    //context.Response.Write(replace2);

                    //lex = new Lexer.Lexer(new SourceCode(replace2));
                    //parser = new Parser(lex);

                    var root = parser.Parse();

                    if (!_semanticIsValidated)
                    {
                        ValidateSemantic(root);
                    }

                    foreach (var statementNode in root)
                    {
                        //statementNode.ValidateSemantic();
                        statementNode.Interpret();
                    }

                    var functiondeclaration = StackContext.Context.FunctionsNodes["operar"];

                    int pos = 0;
                    foreach (var parameter in functiondeclaration.Parameters)
                    {
                        var typeOfParameter =
                            StackContext.Context.Stack.Peek()
                                .GetVariable(parameter.NameOfVariable.Value, functiondeclaration.Position);

                        dynamic value = null;

                        if (typeOfParameter is StringType)
                        {
                            value = new StringValue {Value = parameters[pos] };
                        }
                        else if (typeOfParameter is IntType )
                        {
                            value = new IntValue { Value = Convert.ToInt32(parameters[pos]) };
                        }

                        StackContext.Context.Stack.Peek().SetVariableValue(parameter.NameOfVariable.Value, value);
                    }

                    dynamic valueOfResponse = functiondeclaration.Execute();

                    context.Response.Write($"<h3>\r\nResponse : {valueOfResponse.Value} </h3> ");


                }

                context.Response.Write("%>" +
                                       "\r\n\r\n" +
                                       "</div>" +
                                       "\r\n" +
                                       "</body>\r\n" +
                                       "</html>");
            }
            catch (Exception exception)
            {
                context.Response.Write($"<h3>{exception.Message}</h3>");

                context.Response.Write("%>" +
                                    "\r\n\r\n" +
                                    "</div>" +
                                    "\r\n" +
                                    "</body>\r\n" +
                                    "</html>");
            }
        }

        public bool IsReusable => true;

        public void ValidateSemantic(List<StatementNode> root)
        {
            foreach (var statementNode in root)
            {
                statementNode.ValidateSemantic();
                _semanticIsValidated = true;
            }
        }

    }
}
