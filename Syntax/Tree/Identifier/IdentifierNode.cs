using System.Collections;
using System.Collections.Generic;
using Lexer;
using Syntax.Exceptions;
using Syntax.Semantic;
using Syntax.Semantic.Types;
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

        public Token Position = new Token();
        public override void ValidateSemantic(Token currentToken)
        {
            BaseType variable;

            //if (StructValue != null)
            //{
            //    variable = StackContext.Context.Stack.Peek().GetVariable(Value);
            //}
            //else
            //{
                 variable = StackContext.Context.Stack.Peek().GetVariable(Value);
         //   }

            if (Assignation != null && !(variable is StructType))
            {
                Assignation.LeftValue = this;
                Assignation.ValidateSemantic(currentToken);
            }

            if (Accessors != null)
            {
                var accessorsAndPointers = StackContext.Context.Stack.Peek().GetVariableAccessorsAndPointers(Value);

                if (accessorsAndPointers.Accessors.Count != Accessors.Count && Accessors[0] is ArrayAccessorNode)
                {
                    throw new SemanticException($"Variable {Value} contains: {accessorsAndPointers.Accessors.Count} array accessor, you're trying to access : {Accessors.Count}");
                }

                foreach (var accessor in Accessors)
                {
                    var typeOfAccessor = accessor.ValidateSemanticType(variable);

                    if (Assignation != null)
                    {
                        var right = Assignation.RightValue.ValidateSemantic();

                        if (!Validations.ValidateReturnTypesEquivalence(right, typeOfAccessor))
                            throw new SemanticException($"You can't assign a {right} to a {typeOfAccessor} at Row: {currentToken.Row}, column : {currentToken.Column}");
                    }
                }
            }

        }

        public  BaseType ValidateTypeSemantic()
        {
            var type = StackContext.Context.GetGeneralType(Value);
            
            if (Accessors != null)
            {
                foreach (var variable in Accessors)
                {
                    type = variable.ValidateSemanticType(type);
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
