// <copyright file="OperatorNode.cs" company="Sonam Yangtso">
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
    /// Abstract class operatorNode class which extends ExpressionTreeNode.
    /// </summary>
    public abstract class OperatorNode : ExpressionTreeNode
    {
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
        /// Gets or sets and sets the Left sub nodes.
        /// </summary>
        public ExpressionTreeNode Left { get; set; }

        /// <summary>
        ///
        /// Gets or sets get and sets the right sub nodes.
        /// </summary>
        public ExpressionTreeNode Right { get; set; }
    }
}
