// <copyright file="RightParentheses.cs" company="PlaceholderCompany">
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
    /// RightParenthesesNode.
    /// </summary>
    internal class RightParentheses : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RightParentheses"/> class.
        /// // sets the operator variable from the base class to '('.
        /// </summary>
        public RightParentheses()
            : base(')')
        {
        }

        /// <summary>
        /// Gets get the precedence of the operator.
        /// </summary>
        public override ushort Precedence => 0;

        /// <summary>
        /// This is an override method that returns the evaluated value.
        /// </summary>
        /// <param name="variables"> variable.</param>
        /// <returns>calcualted value.</returns>
        public override double Evaluate(ref Dictionary<string, double> variables)
        {
            return 0.0;
        }
    }
}
