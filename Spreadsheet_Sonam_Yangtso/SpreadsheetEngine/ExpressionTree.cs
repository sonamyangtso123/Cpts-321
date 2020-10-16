// CptS 321: Expression Tree Code Demo of how NOT to code your assignements
// Problems and sollutions of this code will be discussed in class
// Note that if you sumbit this code you will not get ANY points for the assignments

using CptS321;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CptS321

{
    public class ExpressionTree
    {
        private ExpressionTreeNode root;

        private Dictionary<string, double> variables = new Dictionary<string, double>();

        public ExpressionTree(string expression)
        {
            this.Expression = expression;
            this.root = this.Compile(expression);
        }

        public string Expression
        {
            get; set;
        }

        private ExpressionTreeNode Compile(string expression)
        {
            char[] operators = { '+', '-', '*', '/', };
            if (string.IsNullOrEmpty(expression))
            {
                return null;
            }
            else
            {
                int expressionIndex = expression.Length - 1;
                while (expressionIndex > 0 && !operators.Contains(expression[expressionIndex]))
                {
                    expressionIndex--;
                }

                if (operators.Contains(expression[expressionIndex]))
                {
                    OperatorNode operatorNode = OperatorNodeFactory.CreateNewNode(expression[expressionIndex]);
                    // and start over with the left and right sub-expressions
                    operatorNode.Left = this.Compile(expression.Substring(0, expressionIndex));
                    operatorNode.Right = this.Compile(expression.Substring(expressionIndex + 1));
                    return operatorNode;

                }

                double number;
                if (double.TryParse(expression, out number))
                {
                    // we need a constantnode
                    ConstantNode newNode = new ConstantNode();

                    newNode.Value = number;
                    return newNode;

                }
                // or variable
                else
                {
                    // we need a variablenode
                    VariableNode newNode = new VariableNode(expression, this.variables);

                    newNode.Name = expression;

                    return newNode;
                }

            }
        }

        //// Precondition: n is non-null
        private double Evaluate(ExpressionTreeNode node)
        {

            ConstantNode constantNode = node as ConstantNode;
            if (constantNode != null)
            {
                return constantNode.Value;
            }

            // as a variable
            VariableNode variableNode = node as VariableNode;
            if (variableNode != null)
            {
                return this.variables[variableNode.Name];
            }

            OperatorNode operatorNode = node as OperatorNode;
            if (operatorNode != null)
            {
                return operatorNode.Evaluate();
            }

            throw new NotSupportedException();

        }

        public double Evaluate()
        {
            return this.Evaluate(this.root);
        }

        public void SetVariable(string name, double value)
        {
            if (this.variables.ContainsKey(name))
            {
                this.variables[name] = value;
            }
            else
            {
                this.variables.Add(name, value);
            }
        }
    }
}
