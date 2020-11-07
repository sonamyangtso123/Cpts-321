// <copyright file="MultiplicationOperatorNode.cs" company="Sonam Yangtso">
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
    /// MultiplicationOperatorNode extends OperatorNode.
    /// </summary>
    public class MultiplicationOperatorNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiplicationOperatorNode"/> class.
        /// Gets the * sign.
        /// </summary>
        public MultiplicationOperatorNode()
            : base('*')
        {
        }

        /// <summary>
        /// Gets the precedence of the Operator.
        /// </summary>
        public override ushort Precedence => 6;

        /// <summary>
        /// Gets the Assocaitivity of the operator.
        /// </summary>
        public static Associative Associativity
        {
            get { return Associative.Left; }
        }

       /// <summary>
        /// This is an override method for Evaluation.
        /// </summary>
        /// <returns> retruns the calculated value. </returns>
        public override double Evaluate(ref Dictionary<string, double> variables)
        {
            return this.Right .Evaluate(ref variables) * this.Left.Evaluate(ref variables);
        }
    }
}
