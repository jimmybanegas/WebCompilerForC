using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Semantic;
using Syntax.Tree.Acessors;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Identifier;

namespace Syntax.Tree.Declarations
{
    public class MultideclarationNode : TypeOfDeclaration
    {
        public GeneralDeclarationNode GeneralNode;
        public List<IdentifierNode> ListOfVariables;
        public override void ValidateSemantic()
        {
            GeneralNode.ValidateSemantic();

            foreach (var variable in ListOfVariables)
            {
                var type = GeneralNode.DataType.ValidateTypeSemantic();

                var variables = new TypesTable.Variable();
              
                if (variable.Accessors != null )
                {
                   variables.Accessors.AddRange(variable.Accessors);
                }

                if (variable.PointerNodes != null)
                {
                   variables.Pointers.AddRange(variable.PointerNodes);
                }
                
                StackContext.Context.Stack.Peek().RegisterType(variable.Value, type,Position,variables);

                variable.ValidateSemantic();
            }
        }

        public override void Interpret()
        {
            dynamic type = GeneralNode.DataType.ValidateTypeSemantic().GetDefaultValue();
            foreach (var variable in ListOfVariables)
            {
                if (variable.Assignation != null)
                {
                    variable.Assignation.LeftValue.StructValue = variable.Assignation.LeftValue.Value;
                    variable.Assignation?.Interpret();
                }
                else
                {
                    StackContext.Context.Stack.Peek().SetVariableValue(variable.Value, type);
                }
            


                //else
                //{
                //    variable.Assignation = new AssignationNode();
                //    variable.Assignation.LeftValue.StructValue = variable.Value;
                //    variable.Assignation?.Interpret();
                //}
            }
        }
    }
}
