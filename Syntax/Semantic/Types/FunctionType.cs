using System;
using System.Collections.Generic;

namespace Syntax.Semantic.Types
{
    public class FunctionType : BaseType
    {
        public override bool IsAssignable(BaseType otherType)
        {
            throw new NotImplementedException();
        }

        public List<ParameterFunction> Parameters;
        public readonly BaseType FunctValue;
        
        public FunctionType(List<ParameterFunction> parameters, BaseType functValue)
        {
            Parameters = parameters;
            FunctValue = functValue;
        }
    }
}
