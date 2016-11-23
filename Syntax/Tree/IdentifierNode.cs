using System;
using System.Collections.Generic;
using Syntax.Tree.Nodes.Acessors;
using Syntax.Tree.Nodes.BaseNodes;
using Syntax.Tree.Nodes.Declarations;

namespace Syntax.Tree
{
    public class IdentifierNode : TypeOfDeclaration
    {
        public string Value { get; set; }
        public List<AccessorNode> Accessors;
        public List<PointerNode> PointerNodes;
        public DeReferenceNode Reference;
        public UnaryOperator IncrementOrdecrement { get; set; }

        public AssignationNode Assignation;

        public override void ValidateSemantic()
        {
            throw new NotImplementedException();
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
