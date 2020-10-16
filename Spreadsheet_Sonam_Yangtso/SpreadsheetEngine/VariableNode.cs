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
            this.variables = new Dictionary<string, double>();
        }

        public VariableNode(string name, Dictionary<string, double> variable)
        {
            this.name = name;
            this.variables = variable;
        }

        public string Name
        {
            get; set;
        }

        public override double Evaluate()
        {
            double value = 0.0;

            value = this.variables[this.Name];

            return value;
        }
    }
}
