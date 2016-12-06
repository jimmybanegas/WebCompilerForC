using System;
using System.Collections.Generic;
using Syntax.Semantic;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Operators.Binary
{
    public class ModuleAndAssignmentOperatorNode : BinaryOperatorNode
    {

        public ModuleAndAssignmentOperatorNode()
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

        public override string GenerateCode()
        {
            return LeftOperand.GenerateCode() + "%=" + RightOperand.GenerateCode();
        }
    }
}
