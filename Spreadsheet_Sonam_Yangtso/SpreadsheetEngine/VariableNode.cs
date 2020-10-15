using CptS321;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    public class VariableNode : ExpressionTreeNode
    {
        private readonly string name;
        private Dictionary<string, double> variables;

        public VariableNode()
        {
        }

        public VariableNode(string name, Dictionary<string, double> variable)
        {
            this.name = name;
            this.variables = variable;
        }

        public string Name
        {
            get;set; 
        }

        public override double Evaluate()
        {

            if (this.variables.ContainsKey(this.Name))
            {
                return this.variables[this.Name];
            }

            return 0.0;
        }
    }
}
