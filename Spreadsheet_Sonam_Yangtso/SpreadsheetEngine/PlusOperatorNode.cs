// <copyright file="PlusOperatorNode.cs" company="Sonam Yangtso">
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
    /// plusoperatorNode.
    /// </summary>
    public class PlusOperatorNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlusOperatorNode"/> class.
        /// gets the plus operator sign.
        /// </summary>
        ///
        public PlusOperatorNode()
            : base('+')
        {
        }

        /// <summary>
        ///
        /// gets the precedence of the operator.
        /// </summary>
        public override ushort Precedence { get; set; } = 5;

        /// <summary>
        /// Evaluate the left and right subnodes.
        /// </summary>
        /// <returns> calcualated value. </returns>
        public override double Evaluate()
        {
            return this.Left.Evaluate() + this.Right.Evaluate();
        }
    }
}
