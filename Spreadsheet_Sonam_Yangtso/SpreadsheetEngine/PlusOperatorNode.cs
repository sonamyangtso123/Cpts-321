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
        /// gets the plus operator sign.
        /// </summary>
        public static char Operator
        {
            get { return '+'; }
        }

         /// <summary>
         ///
         /// gets the precedence of the operator.
         /// </summary>
        public static ushort Precedence
        {
            get { return 2; }
        }

        /// <summary>
        /// gets the left associative.
        /// </summary>
        public static Associative Associativity
        {
            get { return Associative.Left; }
        }

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
