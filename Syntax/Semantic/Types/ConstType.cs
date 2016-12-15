using System;
using Syntax.Interpret;
using Syntax.Tree.Declarations;

namespace Syntax.Semantic.Types
{
    public class ConstType : BaseType
    {
        public override string ToString()
        {
            return "Const";
        }

        public override Value GetDefaultValue()
        {
            throw new NotImplementedException();
        }

        public AssignationNode Assignation;
        public BaseType Type;

    }
}