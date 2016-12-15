using System;
using System.Collections.Generic;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Tree.Acessors;

namespace Syntax.Semantic.Types
{
    public class FunctionType : BaseType
    {
        public List<ParameterFunction> Parameters;
        public readonly BaseType FunctValue;
        
        public FunctionType(List<ParameterFunction> parameters, BaseType functValue)
        {
            Parameters = parameters;
            FunctValue = functValue;
        }

        public override Value GetDefaultValue()
        {
            return new IntValue();
        }
    }
}
