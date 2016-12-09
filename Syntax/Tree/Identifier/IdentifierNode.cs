using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public override void ValidateSemantic()
        {
            BaseType variable;
        
            variable = StackContext.Context.Stack.Peek().GetVariable(Value);

            if (Assignation != null && !(variable is StructType))
            {
                Assignation.LeftValue = this;
                Assignation.ValidateSemantic();
            }

            BaseType typeOfAccessorStruct = null;
            string nameOfProperty = null;

            if (variable is StructType)
            {
                var list = ((StructType)variable).Elements;

                foreach (var element in list)
                {
                    foreach (var accessor in Accessors)
                    {
                        if (accessor is PropertyAccessorNode)
                        {
                            nameOfProperty = (accessor as PropertyAccessorNode).IdentifierNode.Value;

                            if (element.Element.ItemDeclaration.NameOfVariable.Value == (accessor as PropertyAccessorNode).IdentifierNode.Value)
                            {
                                typeOfAccessorStruct = element.Element.ItemDeclaration.DataType.ValidateTypeSemantic();
                            }
                        }
                    }
                }
            }


            if (Accessors != null)
            {
                var accessorsAndPointers = StackContext.Context.Stack.Peek().GetVariableAccessorsAndPointers(Value);

                var arrayAccessorsCount = Accessors.Count(a => a is ArrayAccessorNode);
                var arrayAccessorsCountFromVariable = accessorsAndPointers.Accessors.Count(a => a is ArrayAccessorNode);

                if (arrayAccessorsCountFromVariable != arrayAccessorsCount)
                {
                    throw new SemanticException($"Variable {Value} contains: {arrayAccessorsCountFromVariable} array accessor," +
                                                $" you're trying to access : {arrayAccessorsCount} at Row: {Position.Row} , Column {Position.Column}");
                }

                foreach (var accessor in Accessors)
                {
                    BaseType typeOfAccessor = null;

                    typeOfAccessor = accessor.ValidateSemanticType(variable);
            
                    if (Assignation != null)
                    {
                        var right = Assignation.RightValue.ValidateSemantic();

                        if (typeOfAccessor is StructType)
                        {
                            if (typeOfAccessorStruct == null)
                            {
                               throw  new SemanticException($"Property {nameOfProperty} doesn't exist in struct at Row: {Position.Row} , Column {Position.Column}");
                            }

                            if (!Validations.ValidateReturnTypesEquivalence(right, typeOfAccessorStruct))
                                throw new SemanticException($"You can't assign a {right} to a {typeOfAccessorStruct} at Row: {Position.Row}, column : {Position.Column}");
                        }
                        else
                        {
                            if (!Validations.ValidateReturnTypesEquivalence(right, typeOfAccessor))
                                throw new SemanticException($"You can't assign a {right} to a {typeOfAccessor} at Row: {Position.Row}, column : {Position.Column}");
                        }
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
