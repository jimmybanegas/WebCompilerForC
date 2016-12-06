﻿using System.Collections;
using System.Collections.Generic;
using Syntax.Semantic;
using Syntax.Tree.Acessors;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Declarations;

namespace Syntax.Tree.Identifier
{
    public class IdentifierNode : TypeOfDeclaration
    {
        public string Value { get; set; }
        public string StructValue { get; set; }
        public List<AccessorNode> Accessors;
        public List<PointerNode> PointerNodes;
        public DeReferenceNode Reference;
        public UnaryOperator IncrementOrdecrement { get; set; }

        public AssignationNode Assignation;

        public override void ValidateSemantic()
        {
            //throw new NotImplementedException();

            var variable = StackContext.Context.Stack.Peek().GetVariable(Value);

            if (Assignation != null)
            {
                Assignation.LeftValue = this;
                Assignation.ValidateSemantic();
            }

        }

        public  BaseType ValidateTypeSemantic()
        {
            //if (TypesTable.Instance.VariableExist(Value))
            //{
            //    return TypesTable.Instance.GetVariable(Value);
            //}

            //  var type = TypesTable.Instance.GetVariable(Value);

            var type = StackContext.Context.GetGeneralType(Value);

            // var type2 = StackContext.Context.Stack.Peek().GetVariable(Value);

            //StackContext.Context.Stack.Push(new TypesTable());

            //var contextos = 

            if (Accessors != null)
            {
                foreach (var variable in Accessors)
                {
                    type = variable.ValidateSemanticType(Value);
                }
            }
           
            return type;
           
        }

        public override string GenerateCode()
        {
            if (Accessors.Count == 0)
                return $"{Value}";

            string accesors = "";
            foreach (var accesorNode in Accessors)
            {
                accesors = accesors + accesorNode.GenerateCode();
            }

            return Value + accesors;
        }
    }
}