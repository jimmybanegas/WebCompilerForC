using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax.Tree
{
    public abstract class BaseType
    {
        public abstract bool IsAssignable(BaseType otherType);
        public abstract string GenerateCode();
    }
}
