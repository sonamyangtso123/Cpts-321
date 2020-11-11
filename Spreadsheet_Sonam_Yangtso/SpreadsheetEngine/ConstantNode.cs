// <copyright file="ConstantNode.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// This is ConstantNode class extends from ExpressionTreeNode.
    /// </summary>
    public class ConstantNode : ExpressionTreeNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNode"/> class.
        /// ConstantNode constructor with value.
        /// </summary>
        /// <param name="value"> value.</param>
        public ConstantNode(double value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNode"/> class.
        /// This is empty ConstantNode constructor.
        /// </summary>
        public ConstantNode()
        {
        }

        /// <summary>
        /// Gets or sets and sets for Value.
        /// </summary>
        public double Value
        {
            get; set;
        }

        /// <inheritdoc/>
        /// Override the Evaluate method
        public override double Evaluate(ref Dictionary<string, double> variables)
        {
            return this.Value;
        }
    }
}
