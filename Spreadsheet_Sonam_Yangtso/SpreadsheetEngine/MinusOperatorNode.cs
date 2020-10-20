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
        /// Gets - sign operator.
        /// </summary>
        public static char Operator
        {
            get { return '-'; }
        }

        /// <summary>
        /// Gets the precedence of this operator.
        /// </summary>
        public static ushort Precedence
        {
            get { return 2; }
        }

        /// <summary>
        /// Gets Left associative.
        /// </summary>
        public static Associative Associativity
        {
            get { return Associative.Left; }
        }

        /// <summary>
        /// It is a evaluate method.
        /// </summary>
        /// <returns> gets the calculated value. </returns>
        public override double Evaluate()
        {
            return this.Left.Evaluate() - this.Right.Evaluate();
        }
    }
}
