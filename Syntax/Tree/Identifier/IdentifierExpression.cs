using System;
using System.Collections.Generic;
using System.Linq;
using Lexer;
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

        public Token Position = new Token();
        public override BaseType ValidateSemantic()
        {
            var type = StackContext.Context.Stack.Peek().GetVariable(Name);

            if (Accessors != null && Accessors.Count>0)
            {
                var accessorsAndPointers = StackContext.Context.Stack.Peek().GetVariableAccessorsAndPointers(Name);

                var arrayAccessorsCount = Accessors.Count(a => a is ArrayAccessorNode);
                var arrayAccessorsCountFromVariable = accessorsAndPointers.Accessors.Count(a => a is ArrayAccessorNode);

                // if (accessorsAndPointers.Accessors.Count != Accessors.Count && Accessors[0] is ArrayAccessorNode)
                if (arrayAccessorsCountFromVariable != arrayAccessorsCount)
                {
                    throw new SemanticException($"Variable {Name} contains: {arrayAccessorsCountFromVariable} array accessor, you're trying to access : {arrayAccessorsCount}");
                }

                foreach (var variable in Accessors)
                {
                      type = variable.ValidateSemanticType(type);
                }
            }

            return type;
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
