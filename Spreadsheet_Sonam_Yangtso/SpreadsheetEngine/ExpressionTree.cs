// <copyright file="ExpressionTree.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using CptS321;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CptS321
{
    /// <summary>
    /// This is ExpressionTree class that builds a tree for expression.
    /// </summary>
    public class ExpressionTree
    {
        /// <summary>
        /// Private root variable.
        /// </summary>
        private ExpressionTreeNode root;

        /// <summary>
        /// This is the dictionary where variables would be stored.
        /// </summary>
        private Dictionary<string, double> variables = new Dictionary<string, double>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// constructor that takes expression as an argument.
        /// </summary>
        /// <param name="expression"> input expression.</param>
        public ExpressionTree(string expression)
        {
            this.Expression = expression;

            // calls compile method
            this.root = this.Compile(expression);
        }

        /// <summary>
        /// Gets or sets and Sets the Expression from ExpressionTree constructor.
        /// </summary>
        public string Expression
        {
            get; set;
        }

        /// <summary>
        /// This method builds the given epression to a ExpressionTree by simplifying it.
        /// </summary>
        /// <param name="expression"> input expression.</param>
        /// <returns>ExptessionTree Node. </returns>
        private ExpressionTreeNode Compile(string expression)
        {
            char[] operators = { '+', '-', '*', '/', };

            // checks if the expression is an empty or null return null
            if (string.IsNullOrEmpty(expression))
            {
                return null;
            }
            else
            {
                // get the last character of the the exprssion
                int expressionIndex = expression.Length - 1;

                // iterate the expression until you get an operator character
                while (expressionIndex > 0 && !operators.Contains(expression[expressionIndex]))
                {
                    expressionIndex--;
                }

                // if we find an operator character
                if (operators.Contains(expression[expressionIndex]))
                {
                    // create an operator node and divide the left and right sub nodes
                    OperatorNode operatorNode = OperatorNodeFactory.CreateNewNode(expression[expressionIndex]);

                    // and start over with the left and right sub-expressions
                    operatorNode.Left = this.Compile(expression.Substring(0, expressionIndex));
                    operatorNode.Right = this.Compile(expression.Substring(expressionIndex + 1));
                    return operatorNode;
                }

                // if the character is an constant value
                double number;
                if (double.TryParse(expression, out number))
                {
                    // we create a constantnode with value equals to number
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

       /// <summary>
       /// This methods evauates each node of the ExpressTree.
       /// </summary>
       /// <param name="node"> node.</param>
       /// <returns> evaluated value.</returns>
        private double Evaluate(ExpressionTreeNode node)
        {
            // if the node is a ConstantNode and it is not null
            ConstantNode constantNode = node as ConstantNode;
            if (constantNode != null)
            {
                // Then return the Constantnode value
                return constantNode.Value;
            }

            // as a variable
            VariableNode variableNode = node as VariableNode;
            if (variableNode != null)
            {
                return this.variables[variableNode.Name];
            }

        // as operatorNode.
            OperatorNode operatorNode = node as OperatorNode;
            if (operatorNode != null)
            {
                // call the Evaluate method from OperatoreNode class.
                return operatorNode.Evaluate();
            }

            // otherwise
            throw new NotSupportedException();
        }

        /// <summary>
        /// Evaluate expressions.
        /// </summary>
        /// <returns>
        /// Returns the evaluated function.
        /// </returns>
        public double Evaluate()
        {
            return this.Evaluate(this.root);
        }

        /// <summary>
        /// if the dictionary conatians the name then set the new value to that name.
        /// if the dictionary doesnot conatians the name then add the name value set to the dictionary.
        /// </summary>
        /// <param name="name">
        /// variable name.
        /// </param>
        /// <param name="value">
        ///  variable value.
        /// </param>
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
