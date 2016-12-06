using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syntax.Semantic.Types;

namespace Syntax.Semantic
{
    public static class Validations
    {
        public static bool ValidateReturnTypesEquivalence(BaseType right, BaseType left)
        {
            if (right is IntType || right is FloatType)
            {
                return left is IntType || left is FloatType || left is BooleanType;
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
    }
    
}
