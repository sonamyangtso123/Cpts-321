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
        /// </summary>
        /// <param name="item"> variable name. </param>
        /// <param name="value">value corresponding to varibale name </param>
        public VariableNode(string item, double value)
        {
            this.Name = item;
            this.Value = value;
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
        ///  This is an override Evaluate method.
        ///  This method returns the value of the corresponding varible name.
        /// </summary>
        /// <returns> value of the varibel name.</returns>
        public override double Evaluate()
        {
            return this.Value;
        }
    }
}

