using System;
using System.Collections.Generic;
using System.Linq;
using Lexer;
using Syntax.Exceptions;
using Syntax.Interpret;
using Syntax.Semantic.Types;
using Syntax.Tree.Acessors;

namespace Syntax.Semantic
{
    public class TypesTable
    {
        private static TypesTable _instance;

        public Dictionary<string, Value> Values;
        public Dictionary<string, BaseType> Table;

        public Dictionary<string, List<Value>> ValuesOfArrays;
        public Dictionary<string, List <Tuple<string, Value>>> ValuesofStructInstances;

        public Dictionary<string, Variable> Variables;
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
            ValuesOfArrays = new Dictionary<string, List<Value>>();
            ValuesofStructInstances = new Dictionary<string, List<Tuple<string, Value>>>();
        }
        public static TypesTable Instance => _instance ?? (_instance = new TypesTable());

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
            var pointer = HasPointer(name);

            foreach (var stack in StackContext.Context.Stack)
            {
                if (stack.Values.ContainsKey(name))
                {
                    if (!string.IsNullOrEmpty(pointer) && string.IsNullOrEmpty(value.Pointer))
                    {
                       // stack.Values[pointer] = value;
                       SetVariableValueWithRightPointer(pointer,value);
                    }
                    else
                    {
                        stack.Values[name] = value;
                    }
                }
            }
        }

        public void SetVariableValueWithRightPointer(string name, Value value)
        {
            foreach (var stack in StackContext.Context.Stack)
            {
                if (stack.Values.ContainsKey(name))
                {
                    stack.Values[name] = value;
                }
            }
        }

        public Value GetVariableValueWithRightPointer(string name)
        {
            foreach (var stack in StackContext.Context.Stack)
            {
                if (stack.Values.ContainsKey(name))
                {
                   return  stack.Values[name];
                }
            }

            return null;
        }
        public Value GetVariableValue(string name)
        {
            var pointer = HasPointer(name);

            foreach (var stack in StackContext.Context.Stack)
            {
                if (stack.Values.ContainsKey(name))
                {
                    if (!string.IsNullOrEmpty(pointer))
                    {
                        var returnVal = GetVariableValueWithRightPointer(pointer);

                        if (returnVal != null)
                        {
                            return returnVal;
                        }
                        break;
                    }

                    return  stack.Values[name] ;
                }
            }
            return null;
        }

        public string HasPointer(string name)
        {
            foreach (var stack in StackContext.Context.Stack)
            {
                if (stack.Values.ContainsKey(name))
                {
                    var value = stack.Values[name];

                    if (!string.IsNullOrEmpty(value.Pointer))
                    {
                        return value.Pointer;
                    }
                }
            }

            return "";
        }

        //Handle Arrays Values
        public void SetArrayVariableValue(string name, Value value)
        {
            bool changed = false;
            foreach (var stack in StackContext.Context.Stack)
            {
                if (stack.ValuesOfArrays.ContainsKey(name))
                {
                    List<Value> existing;
                    if (!stack.ValuesOfArrays.TryGetValue(name, out existing))
                    {
                        existing = new List<Value>();
                        stack.ValuesOfArrays[name] = existing;
                    }

                    int pos = 0;
                    foreach (var value1 in existing.ToList())
                    {
                        if (value1.Position1 == value.Position1 && value1.Position2 == value.Position2)
                        {
                            existing[pos] = value;
                            changed = true;
                        }
                        pos++;
                    }
                }
            }

            if (!changed)
            {
                throw new Exception($"Position {value.Position1},{value.Position2} doesn't exist in array {name}");
            }
        }

        internal void SetArrayVariableValue(string name, List<Value> values)
        {
            foreach (var stack in StackContext.Context.Stack)
            {
                if (stack.Values.ContainsKey(name))
                {
                    stack.ValuesOfArrays[name] = values;
                }
            }
        }
        public List<Value> GetArrayVariableValues(string name)
        {
            foreach (var stack in StackContext.Context.Stack)
            {
                if (stack.Values.ContainsKey(name))
                {
                    return stack.ValuesOfArrays[name];
                }
            }
            return null;
        }

        //Handle Struct Instances Values
        public void SetStructVariableValue(string name, Tuple<string,Value> value)
        {
            foreach (var stack in StackContext.Context.Stack)
            {
                List<Tuple<string,Value>> existing;

                if (!stack.ValuesofStructInstances.TryGetValue(name, out existing))
                {
                    existing = new List<Tuple<string, Value>>();

                    stack.ValuesofStructInstances[name] = existing;
                }

                foreach (var tuple in existing.ToList())
                {
                    if (tuple.Item1 == value.Item1)
                    {
                        existing.Remove(tuple);
                    }
                }

                existing.Add(value);
            }
        }

        public List <Tuple<string,Value>> GetStructVariableValues(string name)
        {
            foreach (var stack in StackContext.Context.Stack)
            {
                if (stack.Values.ContainsKey(name))
                {
                    return stack.ValuesofStructInstances[name];
                }
            }
            return null;
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

