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
    internal class DivisionOperatorNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DivisionOperatorNode"/> class.
        /// Gets static method this returns the Operator sign.
        /// </summary>
        ///
        public DivisionOperatorNode()
            : base('/')
        {
        }



        /// <summary>
        /// gets the precedence of the operator.
        /// </summary>
        public override ushort Precedence => 6;

        public static Associative Associativity => Associative.Left;

        /// <summary>
        /// Gets the Assocaitivity of the operator.
        /// </summary>

        /// <summary>
        /// This is an override method that returns the evaluated value.
        /// </summary>
        /// <returns> caluated value. </returns>
        public override double Evaluate()
        {
            return this.Right.Evaluate() / this.Left.Evaluate();
        }
    }
}
