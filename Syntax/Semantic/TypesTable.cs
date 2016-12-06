using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                {"bool", new BooleanType()},
                {"struct", new StructType()},
                {"enum", new EnumType() }
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

        public void RegisterType(string name, BaseType baseType)
        {
            if (StackContext.Context.Stack.Peek().Table.ContainsKey(name))
            {
                throw new SemanticException($"Type :{name} exists.");
            }

            Table.Add(name, baseType);
        }

        public BaseType GetVariable(string name)
        {
            //if (Table.ContainsKey(name))
            //{
            //    return Table[name];
            //}

            foreach (var stack in StackContext.Context.Stack)
            {
                if (stack.Table.ContainsKey(name))
                {
                    return stack.Table[name];
                }
            }

            throw new SemanticException($"Type :{name} doesn't exists.");
        }

        public bool VariableExist(string name)
        {

            foreach (var stack in StackContext.Context.Stack)
            {
                if (stack.Table.ContainsKey(name))
                {
                    return stack.VariableExist(name);
                }
            }

            return false;
            // return StackContext.Context.Stack.Peek().Table.ContainsKey(name);
        }

    }

    public class StackContext
    {
        private static StackContext _context;
        public Stack<TypesTable> Stack = new Stack<TypesTable>();
        public Dictionary<string, BaseType> TableOfTypes;

        private StackContext()
        {
           Stack.Push(new TypesTable());

            TableOfTypes = new Dictionary<string, BaseType>
            {
                {"int", new IntType()},
                {"string", new StringType()},
                {"float", new FloatType()},
                {"date", new DateType()},
                {"char", new CharType()},
                {"bool", new BooleanType()},
                {"struct", new StructType()},
                {"enum", new EnumType() }
            };
        }

        public static StackContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new StackContext();
                }
                return _context;
            }
        }

        public BaseType GetGeneralType(string name)
        {
            return TableOfTypes[name];
        }

    }

}

