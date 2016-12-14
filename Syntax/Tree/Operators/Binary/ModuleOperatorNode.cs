using System;
using System.Collections.Generic;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Binary
{
    public class ModuleOperatorNode : BinaryOperatorNode
    {
        public ModuleOperatorNode()
        {
            Validation = new Dictionary<Tuple<BaseType, BaseType>, BaseType>
            {
                 {
                    new Tuple<BaseType, BaseType>(StackContext.Context.GetGeneralType("int"),
                            StackContext.Context.GetGeneralType("int")),
                        StackContext.Context.GetGeneralType("int")
                }
            };
        }
      
        public override string Interpret()
        {
            return LeftOperand.Interpret() + "%" + RightOperand.Interpret();
        }
    }
}
