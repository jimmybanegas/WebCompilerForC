using System.Collections.Generic;
using Lexer;
using Syntax.Exceptions;
using Syntax.Interpret;
using Syntax.Semantic.Types;
using Syntax.Tree.Acessors;

namespace Syntax.Semantic
{
    public class TypesTable
    {
        public Dictionary<string, BaseType> Table;

        private static TypesTable _instance;

        public Dictionary<string, Variable> Variables;
        public Dictionary<string, Value> Values;

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
                {"double", new FloatType()},
                {"decimal", new FloatType()},
                {"long", new IntType()}
            };

            Variables = new Dictionary<string, Variable>();
            Values = new Dictionary<string, Value>();
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

        public void RegisterType(string name, BaseType baseType, Token currentToken, Variable variable)
        {
            if (StackContext.Context.Stack.Peek().Table.ContainsKey(name))
            {
                throw new SemanticException($"Type: {name} already exists.  Row: {currentToken.Row}, Column: {currentToken.Column}");
            }

            Table.Add(name, baseType);
            Values.Add(name, baseType.GetDefaultValue());

            Variables.Add(name, new Variable {Accessors = variable.Accessors, Pointers = variable.Pointers});
        }

        public  BaseType GetVariable(string name, Token currentToken)
        {
            foreach (var stack in StackContext.Context.Stack)
            {
                if (stack.Table.ContainsKey(name))
                {
                    return stack.Table[name];
                }
            }

            throw new SemanticException($"Type: {name} doesn't exists. Row: {currentToken.Row}, Column: {currentToken.Column}");
        }

        public Variable GetVariableAccessorsAndPointers(string name)
        {
            foreach (var stack in StackContext.Context.Stack)
            {
                if (stack.Variables.ContainsKey(name))
                {
                    return stack.Variables[name];
                }
            }

            throw new SemanticException($"Type: {name} doesn't exists.");
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

        public void SetVariableValue(string name, Value value)
        {
            //Si es rreglo
            //if (_accesores[name])
            //{
            //    List<Value> existing;

            //    if (!_valuesOfArrays.TryGetValue(name, out existing))
            //    {
            //        existing = new List<Value>();
            //        _valuesOfArrays[name] = existing;
            //    }

            //    existing.Add(value);
            //}
            //else
            //{
                Values[name] = value;
           // }

        }

        public Value GetVariableValue(string name)
        {
            return Values[name];
        }


        public class Variable
        {
            public List<PointerNode> Pointers { get; set; }
            public List<AccessorNode> Accessors { get; set; }

            public Variable() 
            {
                Pointers = new List<PointerNode>();
                Accessors = new List<AccessorNode>();
            }
        }

    }
}

