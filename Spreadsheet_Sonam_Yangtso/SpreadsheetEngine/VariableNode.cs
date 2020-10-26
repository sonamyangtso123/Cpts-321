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
        // </summary>
        public VariableNode(string item,double value )
        {
            this.Name = item;
            this.Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="name"> varaibel name.</param>
        /// <param name="variable"> dictionary that holds name value pair.</param>
      
        /// <summary>
        /// Gets or sets get and set the varible name.
        /// </summary>
        public string Name
        {
            get; set;
        }
        
        public double Value { get; set; }

        /// <summary>
        ///  returns the value of the corresponding varible name.
        /// </summary>
        /// <returns> value of the varibel name.</returns>
        public override double Evaluate()
        {
            return Value;
        }
    }
}
