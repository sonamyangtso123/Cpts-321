// <copyright file="VariableNode.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using CptS321;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// VariableNode class which extends ExpressionTreeNode.
    /// </summary>
    public class VariableNode : ExpressionTreeNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// variableNode.
        /// </summary>
        /// <param name="name">variable name.</param>
        public VariableNode(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets get and set the varible name.
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets get and set the varible value.
        /// </summary>
        public double Value
        {
            get; set;
        }

        /// <summary>
        /// This is an override method that returns the evaluated value.
        /// </summary>
        /// <param name="variables"> variable.</param>
        /// <returns>calcualted value.</returns>
        public override double Evaluate(ref Dictionary<string, double> variables)
        {
            return variables[this.Name];
        }
    }
}
