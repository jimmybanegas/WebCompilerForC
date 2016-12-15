using System.Collections.Generic;
using Syntax.Interpret;
using Syntax.Tree.Acessors;

namespace Syntax.Semantic
{
    public abstract class BaseType
    {
        public abstract Value GetDefaultValue();
    }
}
