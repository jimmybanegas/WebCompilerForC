using System;
using System.IO;
using System.Web;

namespace ConsoleTest
{
    class HandlerFiles
    {
        public readonly string _defaultPath = Directory.GetParent(@"..\..\..\").FullName + @"\code1.c";
        public readonly string _defaultPathLexer = Directory.GetParent(@"..\..\..\").FullName + @"\lexer.c";

        public HandlerFiles()
        {

        }

        public HandlerFiles(string path)
        {
            _defaultPath = path;
        }

        public string GetCode()
        {
            string file;
            try
            {
                file = File.ReadAllText(_defaultPath);
              //  file = Regex.Replace(File.ReadAllText(_defaultPath), @"[\r\t]+", "");

            }
            catch (Exception e)

            {
                Console.Write(" No se ha encontrado el archivo");
                return "";
            }
            return file;

        }

        public void WriteCode(string code)
        {
            try
            {
                File.AppendAllText(_defaultPathLexer, code);
            }
            catch (Exception e)
            {
                System.Console.Write(" No se ha encontrado el archivo");
            }
        }
    }
}
