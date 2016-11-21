using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree
{
    public class IdentifierNode : TypeOfDeclaration
    {
        public string Value { get; set; } 
        public List<AccessorNode> Accessors = new List<AccessorNode>();

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
            return this.Value + accesors;
        }
    }
}
