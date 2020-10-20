// <copyright file="OperatorNodeFactory.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CptS321
{
    /// <summary>
    /// operatorNodefactory is class that return all the operator Nodes.
    /// </summary>
    internal class OperatorNodeFactory
    {
        /// <summary>
        /// this method returns an operator node based on the types of operator argument passed.
        /// </summary>
        /// <param name="op"> operator. </param>
        /// <returns> operatorNode. </returns>
        public static OperatorNode CreateNewNode(char op)
        {
            switch (op)
            {
                case '+':
                    return new PlusOperatorNode();

                case '-':
                    return new MinusOperatorNode();

                case '*':
                    return new MultiplicationOperatorNode();

                case '/':
                    return new DivisionOperatorNode();

                default:
                    return null;
            }
        }
    }
}
