// <copyright file="OperatorNode.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This is the operatorNode. It inherits from Node class. Has different function such as evaluate
    /// and do operator functions.
    /// </summary>
    public abstract class OperatorNode : ExpressionTreeNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// </summary>
        /// <param name="op"> sign for corresponding operator.</param>
        public OperatorNode(char op)
        {
            this.Operator = op;
        }

        /// <summary>
        /// enum for Assciative left and right.
        /// </summary>
        public enum Associative
        {
            /// <summary>
            /// retruns right
            /// </summary>
            Right,

            /// <summary>
            /// returns left
            /// </summary>
            Left,
        }

       /// <summary>
        /// Gets an operator.
        /// </summary>
        public char Operator { get; }

        /// <summary>
        /// Gets or sets the left child of node.
        /// </summary>
        public ExpressionTreeNode Left { get; set; }

        /// <summary>
        /// Gets or sets the right childe of node.
        /// </summary>
        public ExpressionTreeNode Right { get; set; }

        /// <summary>
        /// Gets the precedence.
        /// </summary>
        public abstract ushort Precedence { get; }

        /// <summary>
        /// Must be overridden in subclasses to perform some evaluation on its contents and return a double result.
        /// </summary>
        /// <returns>
        /// double value after evaluation.
        /// </returns>
        public abstract override double Evaluate();
    }
}
