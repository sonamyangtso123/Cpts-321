// <copyright file="DivisionOperatorNode.cs" company="Sonam Yangtso">
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
    /// DivisionOperatorNode extends from OperatorNode.
    /// </summary>
    public class DivisionOperatorNode : OperatorNode
    {
        /// <summary>
        /// Gets static method this returns the Operator sign.
        /// </summary>
        public static char Operator
        {
            get { return '/'; }
        }

        /// <summary>
        /// gets the precedence of the operator.
        /// </summary>
        public static ushort Precedence
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets the Assocaitivity of the operator.
        /// </summary>
        public static Associative Associativity
        {
            get { return Associative.Left; }
        }

        /// <summary>
        /// This is an override method that returns the evaluated value.
        /// </summary>
        /// <returns> caluated value. </returns>
        public override double Evaluate()
        {
            return this.Left.Evaluate() / this.Right.Evaluate();
        }
    }
}
