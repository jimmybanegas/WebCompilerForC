using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic.Types;

namespace Syntax.Semantic
{
    public static class Validations
    {
        public static bool ValidateReturnTypesEquivalence(BaseType right, BaseType left)
        {
            if (right is IntType || right is FloatType)
            {
                return left is IntType || left is FloatType || left is BooleanType || left is CharType;
            }

            if (right is BooleanType)
            {
                return left is IntType || left is BooleanType;
            }

            if (right is CharType || right is StringType)
            {
                return left is IntType || left is BooleanType || left is CharType || left is StringType;
            }
            
            if (right is DateType)
            {
                return left is DateType;
            }
            
            return false;
        }

        public static Value GetTypeValue(Value type)
        {
            if(type is StringValue)
                return new StringValue();

            if (type is IntValue)
                return new IntValue();

            if (type is BoolValue)
                return new BoolValue();

            if (type is DateValue)
                return new DateValue();

            if (type is CharValue)
                return new CharValue();

            if (type is FloatValue)
                return new FloatValue();

            return null;
        }

        public static object GetTypeValue(object type, dynamic value)
        {
            var t = type.GetType();

            if (t.Name == "StringValue")
                return new StringValue {Value = value};

            if (t.Name == "IntValue")
                return new IntValue {Value = Convert.ToInt32(value)};

            if (t.Name == "Boolean")
                return new BoolValue { Value = value };

            if (t.Name == "DateValue")
                return new DateValue { Value = value };

            if (t.Name == "CharValue")
                return new CharValue { Value = value };

            if (t.Name == "FloatValue")
                return new FloatValue { Value = value };

            return null;
        }
    }
    
}
