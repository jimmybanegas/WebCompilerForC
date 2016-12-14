using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax.Interpret
{
    public abstract class Value
    {
        public abstract Value Clone();
    }
}
