using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syntax.Tree.Nodes.BaseNodes;

namespace Syntax.Tree
{
    public class IdentifierNode : ExpressionNode
    {
        public string Value { get; set; }
        public List<AccesorNode> Accesors = new List<AccesorNode>();

        public override BaseType ValidateSemantic()
        {
            throw new NotImplementedException();
        }

        public override string GenerateCode()
        {
            if (Accesors.Count == 0)
                return $"{Value}";

            string accesors = "";
            foreach (var accesorNode in Accesors)
            {
                accesors = accesors + accesorNode.GeneratedCodeAttribute();


            }
            return this.Value + accesors;
        }
    }
}
