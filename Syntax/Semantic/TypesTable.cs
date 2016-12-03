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

        private TypesTable()
        {
            Table = new Dictionary<string, BaseType>
            {
                {"int", new IntType()},
                {"string", new StringType()},
                {"float", new FloatType()},
                {"date", new DateType()},
                {"char", new CharType()},
                {"bool", new BooleanType()},
              //  {"const", new ConstType()},
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
            if (Table.ContainsKey(name))
            {
                throw new SemanticException($"Type :{name} exists.");
            }

            //if (Table.)
            //    throw new SemanticException($"  :{name} is a type.");

            Table.Add(name, baseType);
        }

        public BaseType GetVariable(string name)
        {
            if (Table.ContainsKey(name))
            {
                return Table[name];
            }

            throw new SemanticException($"Type :{name} doesn't exists.");
        }

        public bool VariableExist(string name)
        {
            return Table.ContainsKey(name);
        }

    }


}
