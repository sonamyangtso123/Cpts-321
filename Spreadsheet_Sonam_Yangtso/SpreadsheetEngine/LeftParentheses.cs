// <copyright file="LeftParentheses.cs" company="PlaceholderCompany">
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
    /// LeftParentheses.
    /// </summary>
    internal class LeftParentheses : CptS321.OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeftParentheses"/> class.
        /// // sets the operator variable from the base class to '('.
        /// </summary>
        public LeftParentheses()
            : base('(')
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
