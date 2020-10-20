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
        /// Gets the * sign.
        /// </summary>
        public static char Operator
        {
            get { return '*'; }
        }

        /// <summary>
        /// Gets the precedence of the Operator.
        /// </summary>
        public static ushort Precedence
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets the left assocaitive of this operator.
        /// </summary>
        public static Associative Associativity
        {
            get { return Associative.Left; }
        }

        /// <summary>
        /// This is an override method for Evaluation.
        /// </summary>
        /// <returns> retruns the calculated value. </returns>
        public override double Evaluate()
        {
            return this.Left.Evaluate() * this.Right.Evaluate();
        }
    }
}
