using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Hosting;
using Lexer;
using Syntax;
using Syntax.Interpret;
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
        public Handler()
        {
            var file = new HandlerFiles();
            var code = file.GetCode();

            Lex = new Lexer.Lexer(new SourceCode(code));

            Parser = new Parser(Lex);
        }


        private bool _semanticIsValidated;
        
        public void ProcessRequest(HttpContext context)
        {
            //    context = new HttpContext(new HttpRequest(String.Empty,String.Empty, queryString: String.Empty));

         //   var handler = new Handler();

            
           
            if (Parser.CurrentToken.TokenType == TokenType.HTMLContent)
            {
                context.Response.Write(Parser.CurrentToken.Lexeme);
            }

            var parameters = new List<string>();

            try
            {
                string[] keys = context.Request.Form.AllKeys;

                if (keys.Length > 0)
                {
                    foreach (var table in StackContext.Context.Stack)
                    {
                        //  table.Table = new Dictionary<string, BaseType>();
                        table.Values = new Dictionary<string, Value>();
                        table.ValuesOfArrays = new Dictionary<string, List<Value>>();
                        table.Variables = new Dictionary<string, TypesTable.Variable>();
                        table.ValuesofStructInstances = new Dictionary<string, List<Tuple<string, Value>>>();
                    }

                    //parser = new Parser(lex);

                    //parser.ValidateSemanticServer();

                    //   parser.Interpret();

                    //context.Response.Write(replace2);

                    //lex = new Lexer.Lexer(new SourceCode(replace2));
                    //parser = new Parser(lex);

                    //StackContext.Context.Stack.Peek().Values.Remove("operar");
                    //StackContext.Context.Stack.Peek().Table.Remove("operar");
                    //StackContext.Context.Stack.Peek().Variables.Remove("operar");

                    //StackContext.Context.Stack.Peek().Values.Remove("operarResponseForServer");
                    //StackContext.Context.Stack.Peek().Table.Remove("operarResponseForServer");
                    //StackContext.Context.Stack.Peek().Variables.Remove("operarResponseForServer");

                    //StackContext.Context.Stack.Peek().Values.Remove("respuesta");
                    //StackContext.Context.Stack.Peek().Table.Remove("respuesta");
                    //StackContext.Context.Stack.Peek().Variables.Remove("respuesta");


                    StackContext.Context.FunctionsNodes.Remove("operar");

                    string arrayparams = "";

                    foreach (var key in HttpContext.Current.Request.Form.AllKeys)
                {
                    var value = HttpContext.Current.Request.Form[key];

                    //context.Response.Write($"key : {key}, Value: {value} \n");

                    int number;
                    var result = int.TryParse(value, out number);

                    if (!result)
                    {
                        value = "\"" + value + "\"";
                    }
                    if (key != "elementsofarray")
                    {
                            parameters.Add(value);
                        }

                        if (key == "elementsofarray")
                        {
                            arrayparams = value.Replace("\"", ""); ;
                        }

                    }

                    string csvString = string.Join(",", parameters);

                    string newValue = "int respuesta = operar(" + csvString + ");";

                    context.Response.Write(newValue);

                    var replace2 = "";
                    if (Lex.SourceCode._sourceCode.Contains("int respuesta = operar();"))
                    {
                        //  var replace = parser.Lexer.SourceCode._sourceCode.Replace("int respuesta = operar();", newValue);
                        replace2 = Lex.SourceCode._sourceCode.Replace("int respuesta = operar();", newValue);
                    }

                    string newValue2 = "int a[5] = {" + arrayparams + "};";

                    context.Response.Write(newValue2);
                    if (Lex.SourceCode._sourceCode.Contains("int a[5] = {};"))
                    {
                        //  var replace = parser.Lexer.SourceCode._sourceCode.Replace("int respuesta = operar();", newValue);
                        replace2 = replace2.Replace("int a[5] = {};",newValue2);
                    }

                    Lex = new Lexer.Lexer(new SourceCode(replace2));
                    Parser = new Parser(Lex);

                    var root = Parser.Parse();

                    //if (!_semanticIsValidated)
                    //{
                        ValidateSemantic(root);
                    //}

                    //foreach (var statementNode in root)
                    //{
                      //  statementNode.ValidateSemantic();
                       // statementNode.Interpret();

                    Interpret(root);
                //    }

                    var functiondeclaration = StackContext.Context.FunctionsNodes["operar"];

                    StackContext.Context.Stack.Push(StackContext.Context.PastContexts[functiondeclaration.CodeGuid]);

                    var pos = 0;
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

                     functiondeclaration.Execute();

                    dynamic var1 = StackContext.Context.Stack.Peek().GetVariableValue(functiondeclaration.Identifier.NameOfVariable.Value+"ResponseForServer");
         
                    context.Response.Write($"<h3>\r\nName : {functiondeclaration.Identifier.NameOfVariable.Value + "ResponseForServer"} </h3> ");

                    context.Response.Write($"<h3>\r\nResponse Operation : {var1.Value} </h3> ");

                    StackContext.Context.Stack.Pop();

                    context.Response.Write("<h4>--------------------------------------------------------</h4> ");
                    context.Response.Write(" FUNCTION CALL AND ARRAY");
                    context.Response.Write("<h4>--------------------------------------------------------</h4> ");

                    dynamic var23 = StackContext.Context.Stack.Peek().GetVariableValue("sum");
                    context.Response.Write($"<h5><i>\r\n Suma de valores de arreglo: {var23.Value} </i></h5> ");

                    context.Response.Write("<h4>--------------------------------------------------------</h4> ");
                    context.Response.Write("<h4> TIPOS DE DATOS - ASIGNACIONES</h4> ");
                    context.Response.Write("<h4>--------------------------------------------------------</h4> ");

                    dynamic var3 = StackContext.Context.Stack.Peek().GetVariableValue("normalizationFactor");
                    context.Response.Write($"<h5><i>r\nNormalizationFactor (float) : {var3.Value} </i></h5> ");

                    dynamic var4 = StackContext.Context.Stack.Peek().GetVariableValue("uno");
                    context.Response.Write($"<h5><i>\r\nUno (hexadecimal) : {var4.Value} </i></h5> ");

                    dynamic var5 = StackContext.Context.Stack.Peek().GetVariableValue("dos");
                    context.Response.Write($"<h5><i>\r\nDos (binario) : {var5.Value} </i></h5>");

                    dynamic var6 = StackContext.Context.Stack.Peek().GetVariableValue("hola");
                    context.Response.Write($"<h5><i>\r\nHola (string) : {var6.Value} </i></h5> ");

                    dynamic var7 = StackContext.Context.Stack.Peek().GetVariableValue("fecha");
                    context.Response.Write($"<h5><i>\r\nFecha (date) : {var7.Value}  </i></h5> ");

                    context.Response.Write("<h4>--------------------------------------------------------</h4> ");
                    context.Response.Write("<h4> POINTERS </h4> ");
                    context.Response.Write("<h4>--------------------------------------------------------</h4> ");

                    //dynamic var8 = StackContext.Context.Stack.Peek().GetVariableValue("p1");
                    //context.Response.Write($"<h3>\r\n Pointer 1 : {var8.Value} </h3> ");

                    //dynamic var9 = StackContext.Context.Stack.Peek().GetVariableValue("p2");
                    //context.Response.Write($"<h3>\r\n Pointer 2 : {var9.Value} </h3> ");

                    //dynamic var10 = StackContext.Context.Stack.Peek().GetVariableValue("p3");
                    //context.Response.Write($"<h3>\r\n Pointer 3 : {var10.Value} </h3> ");

                    //dynamic var11 = StackContext.Context.Stack.Peek().GetVariableValue("p4");
                    //context.Response.Write($"<h3>\r\n Pointer4 : {var11.Value} </h3> ");

                    dynamic var12 = StackContext.Context.Stack.Peek().GetVariableValue("pc");
                    context.Response.Write($"<h5><i>\r\n Pointer PC: {var12.Value} </i></h5>");

                    dynamic var13 = StackContext.Context.Stack.Peek().GetVariableValue("c");
                    context.Response.Write($"<h5><i>\r\n Pointer C : {var13.Value} </i></h5>");


                    context.Response.Write("<h4>--------------------------------------------------------</h4> ");
                    context.Response.Write("<h4> STRUCTS </h4> ");
                    context.Response.Write("<h4>--------------------------------------------------------</h4> ");

                    dynamic var14 = StackContext.Context.Stack.Peek().GetVariableValue("nombreantes");
                    context.Response.Write($"<h5><i>\r\n Nombre antes : {var14.Value} </i></h5>");

                    dynamic var15 = StackContext.Context.Stack.Peek().GetVariableValue("nombre");
                    context.Response.Write($"<h5><i>\r\n Nombre : {var15.Value} </i></h5>");

                    context.Response.Write("<h4>--------------------------------------------------------</h4> ");
                    context.Response.Write(" ENUMS ");
                    context.Response.Write("<h4>--------------------------------------------------------</h4> ");

                    dynamic var16 = StackContext.Context.Stack.Peek().GetVariableValue("sec_level");
                    context.Response.Write($"<h5><i>\r\n sec_level : {var16.Value} </h3> ");
                    
                    dynamic var17 = StackContext.Context.Stack.Peek().GetVariableValue("my_security_level");
                    context.Response.Write($"<h5><i>\r\n my_security_level : {var17.Value} </i></h5> ");


                    context.Response.Write("<h4>--------------------------------------------------------</h4> ");
                    context.Response.Write(" ARRAYS ");
                    context.Response.Write("<h4>--------------------------------------------------------</h4> ");

                    dynamic var18 = StackContext.Context.Stack.Peek().GetVariableValue("azantes");
                    context.Response.Write($"<h5><i>\r\n Bidimensional arr antes: {var18.Value} </i></h5> ");

                    dynamic var19 = StackContext.Context.Stack.Peek().GetVariableValue("azdespues");
                    context.Response.Write($"<h5><i>\r\n Bidimensional arr antes: {var19.Value} </i></h5> ");

                    dynamic var20 = StackContext.Context.Stack.Peek().GetVariableValue("mark1pos");
                    context.Response.Write($"<h5><i>\r\n Unidimensional arr : {var20.Value} </i></h5> ");

                    context.Response.Write("<h4>--------------------------------------------------------</h4> ");
                    context.Response.Write(" FUNCTION REFERENCE CALL ");
                    context.Response.Write("<h4>--------------------------------------------------------</h4> ");

                    dynamic var21 = StackContext.Context.Stack.Peek().GetVariableValue("valuereference");
                    context.Response.Write($"<h5><i>\r\n Variable pasada con valor 20 : {var21.Value} </i></h5> ");

                    dynamic var22 = StackContext.Context.Stack.Peek().GetVariableValue("valuereferenceresponse");
                    context.Response.Write($"<h5><i>\r\n Valor de retorno de funcion : {var22.Value} </i></h5> ");

                    context.Response.Write("<h4>--------------------------------------------------------</h4> ");
                    context.Response.Write(" TODOS LOS VALORES ");
                    context.Response.Write("<h4>--------------------------------------------------------</h4> ");

                    foreach (var table in StackContext.Context.Stack)
                    {
                        foreach (var var in table.Values)
                        {
                            dynamic va = var.Value;
                            context.Response.Write($"<h5><i>\r\n Valor de  : {var.Key.ToUpper()} es : { va.Value}</i></h5> ");
                        }
                    }

                    foreach (var table in StackContext.Context.Stack)
                    {
                    //  table.Table = new Dictionary<string, BaseType>();
                        table.Values = new Dictionary<string, Value>();
                        table.ValuesOfArrays = new Dictionary<string, List<Value>>();
                        table.Variables = new Dictionary<string, TypesTable.Variable>();
                        table.ValuesofStructInstances = new Dictionary<string, List<Tuple<string, Value>>>();
                    }


                  
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
                // context.Response.Write($"<h3>{exception.Message} and {exception.InnerException} and {exception.StackTrace} and {exception.Source} and {exception.HelpLink}</h3>");
                context.Response.Write($"<h3>{exception.Message} </h3>");

                context.Response.Write("%>" +
                                    "\r\n\r\n" +
                                    "</div>" +
                                    "\r\n" +
                                    "</body>\r\n" +
                                    "</html>");
            }
        }

        public Parser Parser { get; set; }

        public Lexer.Lexer Lex { get; set; }

        public bool IsReusable => false;

        public void ValidateSemantic(List<StatementNode> root)
        {
            foreach (var statementNode in root)
            {
                statementNode.ValidateSemantic();
                _semanticIsValidated = true;
            }
        }

        public void Interpret(List<StatementNode> root)
        {
            foreach (var statementNode in root)
            {
                statementNode.Interpret();
            }
        }




    }
}
