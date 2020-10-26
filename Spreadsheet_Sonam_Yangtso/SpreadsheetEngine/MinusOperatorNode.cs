// <copyright file="MinusOperatorNode.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CptS321;

namespace CptS321
{
    /// <summary>
    /// MinusOperaotrNode extends OperatorNode.
    /// </summary>
    public class MinusOperatorNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MinusOperatorNode"/> class.
        /// Gets - sign operator.
        /// </summary>
        public MinusOperatorNode()
            : base ('-')
        {

        }

        /// <summary>
        /// Gets the precedence of this operator.
        /// </summary>
        public override ushort Precedence { get; set; } = 5;

        /// <summary>
        /// It is a evaluate method.
        /// </summary>
        /// <returns> gets the calculated value. </returns>
        public override double Evaluate()
        {
            return this.Right.Evaluate() - this.Left.Evaluate();
        }
    }
}
