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
            : base('-')
        {
        }

        /// <summary>
        /// Gets the precedence of this operator.
        /// </summary>
        public override ushort Precedence => 5;

        /// <summary>
        /// Gets the Assocaitivity of the operator.
        /// </summary>
        public static Associative Associativity => Associative.Left;

        /// <summary>
        /// This is an override method that returns the evaluated value.
        /// </summary>
        /// <param name="variables"> variable.</param>
        /// <returns>calcualted value.</returns>
        public override double Evaluate(ref Dictionary<string, double> variables)
        {
            return this.Right.Evaluate(ref variables) - this.Left.Evaluate(ref variables);
        }
    }
}
