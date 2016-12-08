using System.Collections.Generic;
using Syntax.Tree.Acessors;

namespace Syntax.Semantic
{
    public abstract class BaseType
    {
        public abstract bool IsAssignable(BaseType otherType);

    }
}
