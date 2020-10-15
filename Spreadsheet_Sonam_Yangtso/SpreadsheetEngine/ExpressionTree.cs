using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    public class ExpressionTree
    {
        private string inputExpression;
        public static Dictionary<string, double> variables = new Dictionary<string, double>();

        public ExpressionTree(string expression)
        {
            this.inputExpression = expression;
            // Implement this constructor to construct the tree from the specific expression
        }

        public string InputExpression
            {
            get { return this.inputExpression; }
            }

        public void SetVaraible(string variableName, double variableValue)
        {
            // Sets the specified variable within the ExpressionTree variables dictionary
        }

        public double Evaluate()
        {
            // Implement this method with no parameters that evaluates the expression to a double
            //value

            return 0;
        }
    }
}
