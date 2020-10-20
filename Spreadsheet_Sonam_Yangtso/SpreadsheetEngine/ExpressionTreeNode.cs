// <copyright file="ExpressionTreeNode.cs" company="Sonam Yangtso">
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
    /// Abstract class ExpressionTreeNode.
    /// </summary>
    public abstract class ExpressionTreeNode
    {
        /// <summary>
        /// It is an abstract method.
        /// </summary>
        /// <returns> nothing. </returns>
        public abstract double Evaluate();
    }
}
