using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic.Types;

namespace Syntax.Semantic
{
    public class TypesTable
    {
        public Dictionary<string, BaseType> Table;

        private static TypesTable _instance;

        public TypesTable()
        {
            Table = new Dictionary<string, BaseType>
            {
                {"int", new IntType()},
                {"string", new StringType()},
                {"float", new FloatType()},
                {"date", new DateType()},
                {"char", new CharType()},
                {"bool", new BooleanType()}
            };
            //_table.Add("function", new FunctionType());
        }
        public static TypesTable Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TypesTable();
                }
                return _instance;
            }
        }

        public void RegisterType(string name, BaseType baseType, Token currentToken)
        {
            if (StackContext.Context.Stack.Peek().Table.ContainsKey(name))
            {
                throw new SemanticException($"Type :{name} already exists at Row: {currentToken.Row}.");
            }

            Table.Add(name, baseType);
        }

        public  BaseType GetVariable(string name)
        {
            foreach (var stack in StackContext.Context.Stack)
            {
                if (stack.Table.ContainsKey(name))
                {
                    return stack.Table[name];
                }
            }

            throw new SemanticException($"Type :{name} doesn't exists.");
        }

        public  bool VariableExist(string name)
        {
            foreach (var stack in StackContext.Context.Stack)
            {
                if (stack.Table.ContainsKey(name))
                {
                    return stack.Table.ContainsKey(name);
                }
            }

            return false;
        }

    }
}

