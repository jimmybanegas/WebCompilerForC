using System;
using System.IO;
using System.Web;

namespace Server
{
    public class HandlerFiles
    {
        private readonly string _defaultPath = System.Web.Hosting.HostingEnvironment.MapPath("~/bin/html.c");
    
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
            }
            catch (Exception e)

            {
                Console.Write(" No se ha encontrado el archivo "+e.Message);
                return "";
            }
            return file;

        }

        public void WriteCode(string code)
        {
            try
            {
               // File.AppendAllText(_defaultPathLexer, code);
            }
            catch (Exception e)
            {
                Console.Write(" No se ha encontrado el archivo "+e.Message);
            }
        }
    }
}