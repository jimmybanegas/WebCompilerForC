using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lexer;
using Syntax.Exceptions;
using Syntax.Interpret;
using Syntax.Interpret.TypesValues;
using Syntax.Semantic;
using Syntax.Semantic.Types;
using Syntax.Tree.Acessors;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Declarations;
using Syntax.Tree.Operators.Unary;

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
        
            variable = StackContext.Context.Stack.Peek().GetVariable(Value, Position);

            if (Assignation != null && !(variable is StructType) && Assignation.RightValue != null)
            {
                Assignation.LeftValue = this;
                Assignation.ValidateSemantic();
            }

            BaseType typeOfAccessorStruct = null;

            string nameOfProperty = null;
            Tuple<string, List<AccessorNode>> property = null;

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
                                property = new Tuple<string, List<AccessorNode>>(nameOfProperty,element.Element.ItemDeclaration.NameOfVariable.Accessors);
                            }
                            
                            //if (element.Element.ItemDeclaration.NameOfVariable.Accessors.Count(a=>a is ArrayAccessorNode) 
                            //    != (accessor as PropertyAccessorNode).IdentifierNode.Accessors.Count(a=>a is ArrayAccessorNode))
                            //{
                            //    throw new SemanticException($"Variable {Value} contains:  array accessor," +
                            //                      $" you're trying to access :  at Row: {Position.Row} , Column {Position.Column}");
                            //}
                        }
                    }
                }
            }


            if (Accessors != null)
            {
                var accessorsAndPointers = StackContext.Context.Stack.Peek().GetVariableAccessorsAndPointers(Value);

                List<AccessorNode> arrayAccess = new List<AccessorNode>();

                if (Accessors.Count > 0)
                {
                    arrayAccess.Add(Accessors[0]);
                    if (Accessors.Count > 1)
                    {
                        arrayAccess.Add(Accessors[1]);
                    }
                }
                
                // var arrayAccessorsCount = Accessors.Count(a => a is ArrayAccessorNode);

                var arrayAccessorsCount = arrayAccess.Count(a => a is ArrayAccessorNode);

                var arrayAccessorsCountFromVariable = accessorsAndPointers.Accessors.Count(a => a is ArrayAccessorNode);

                if (property?.Item2 != null && property.Item2.Count > 0)
                {
                    var accessorsInProperty = property.Item2.Count(a => a is ArrayAccessorNode);

                    if (accessorsInProperty != arrayAccessorsCount)
                    {
                        throw new SemanticException($"Property {nameOfProperty} contains: {accessorsInProperty} array accessor," +
                                                    $" you're trying to access : {arrayAccessorsCount} at Row: {Position.Row} , Column {Position.Column}");
                    }
                }
                else
                {
                    if (arrayAccessorsCountFromVariable != arrayAccessorsCount)
                    {
                        throw new SemanticException($"Variable {Value} contains: {arrayAccessorsCountFromVariable} array accessor," +
                                                    $" you're trying to access : {arrayAccessorsCount} at Row: {Position.Row} , Column {Position.Column}");
                    }
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

        public override void Interpret()
        {
            //If LeftValue is null ; then is struct
            var type = StackContext.Context.Stack.Peek().GetVariable(Value,Position);

            if (type is StructType){
                    
           // {
                    if (Assignation?.RightValue != null)
                    {
                        dynamic valueOfAssignation = Assignation.RightValue.Interpret();

                        var propertyName = ((PropertyAccessorNode)Accessors[0]).IdentifierNode.Value;

                        var propertyAndValue = new Tuple<string, Value>(propertyName, valueOfAssignation);

                        StackContext.Context.Stack.Peek().SetStructVariableValue(Value, propertyAndValue);

                    return;
                    }
            //    }
            }


            if (type is EnumType)
            {
                var nameOfEnumItemIndex = String.Empty;
                if ((Assignation.RightValue as ExpressionUnaryNode)?.Factor is IdentifierExpression)
                {
                    foreach (var element in (type as EnumType).Elements)
                    {
                         nameOfEnumItemIndex =
                            ((IdentifierExpression) (Assignation.RightValue as ExpressionUnaryNode).Factor).Name;

                        if (element.Element.ItemName.Value == nameOfEnumItemIndex)
                        {
                            int? pos = element.Element.OptionalPosition.Value;
                            StackContext.Context.Stack.Peek().SetVariableValue(Value, new StringValue {Value = nameOfEnumItemIndex, Position1 = pos});
                            return;
                        }
                    }   
                }
                throw new Exception($"The item {nameOfEnumItemIndex} doesn't exist in the enum type");
            }

            //if (Assignation.LeftValue != null )
            //{
                if (Assignation?.RightValue != null)
                {
                    Assignation.LeftValue.StructValue = Value;
                    Assignation.Interpret();
                }

                if (IncrementOrdecrement != null)
                {
                    if (IncrementOrdecrement is PreDecrementOperatorNode)
                    {
                        dynamic valueBefore = StackContext.Context.Stack.Peek().GetVariableValue(Value);

                        valueBefore.Value = valueBefore.Value - 1;

                        StackContext.Context.Stack.Peek().SetVariableValue(Value, valueBefore);
                    }
                    else if (IncrementOrdecrement is PreIncrementOperatorNode)
                    {
                        dynamic valueBefore = StackContext.Context.Stack.Peek().GetVariableValue(Value);

                        valueBefore.Value = valueBefore.Value + 1;

                        StackContext.Context.Stack.Peek().SetVariableValue(Value, valueBefore);
                    }
                    else if (IncrementOrdecrement is PostIncrementOperatorNode)
                    {
                        dynamic valueBefore = StackContext.Context.Stack.Peek().GetVariableValue(Value);

                        valueBefore.Value = valueBefore.Value + 1;

                        StackContext.Context.Stack.Peek().SetVariableValue(Value, valueBefore);
                    }
                    else if (IncrementOrdecrement is PostDecrementOperatorNode)
                    {
                        dynamic valueBefore = StackContext.Context.Stack.Peek().GetVariableValue(Value);

                        valueBefore.Value = valueBefore.Value - 1;

                        StackContext.Context.Stack.Peek().SetVariableValue(Value, valueBefore);
                    }
                }
        //    }
        
        }
    }
}
