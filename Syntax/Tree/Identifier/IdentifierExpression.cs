using System;
using System.Collections.Generic;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Tree.Acessors;
using Syntax.Tree.BaseNodes;

namespace Syntax.Tree.Identifier
{
    public class IdentifierExpression : ExpressionNode
    {
        public string Name { get; set; }
        public UnaryOperator IncrementOrdecrement { get; set; }
        public List<AccessorNode> Accessors = new List<AccessorNode>();
        
        public override BaseType ValidateSemantic()
        {

            //if (TypesTable.Instance.VariableExist(Name))
            //{
            //    return TypesTable.Instance.GetVariable(Name);
            //}

            var type = TypesTable.Instance.GetVariable(Name);

            foreach (var variable in Accessors)
            {
              //  type = variable.ValidateSemanticType(type);
            }

            return type;


            //if (!TypesTable.Instance.VariableExist(Name))
            //    throw new SemanticException($"Variable {Name} doesn't exist");

            //return TypesTable.Instance.GetVariable(Name);
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
