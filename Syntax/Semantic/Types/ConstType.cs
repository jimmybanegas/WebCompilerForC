using System;
using Syntax.Tree.Declarations;

namespace Syntax.Semantic.Types
{
    public class ConstType : BaseType
    {
        public override string ToString()
        {
            return "Const";
        }

        public override bool IsAssignable(BaseType otherType)
        {
            throw new NotImplementedException();
        }

        public AssignationNode Assignation;
        public BaseType Type;

    }
}