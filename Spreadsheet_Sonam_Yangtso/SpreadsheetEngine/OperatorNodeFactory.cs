// <copyright file="OperatorNodeFactory.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CptS321
{
    /// <summary>
    /// operatorNodefactory is class that return all the operator Nodes.
    /// </summary>
    internal class OperatorNodeFactory
    {
        /// <summary>
        /// We will load all classes that
        /// implement our OperatorNode class and add it to our dictionary Varaibles.
        /// </summary>
#pragma warning disable SA1401 // Fields should be private
        public static Dictionary<char, Type> Variables = new Dictionary<char, Type>
#pragma warning restore SA1401 // Fields should be private
        {
            { '+', typeof(PlusOperatorNode) },
            { '-', typeof(MinusOperatorNode) },
            { '*', typeof(MultiplicationOperatorNode) },
            { '/', typeof(DivisionOperatorNode) },
        };

        /// <summary>
        /// creates an instance of an operator node for an given node.
        /// </summary>
        /// <param name="op">Op.</param>
        /// <returns>the operator node .</returns>
        public static OperatorNode CreateNewNode(char op)
        {
            if (Variables.ContainsKey(op))
            {
                object operatorNodeObject = System.Activator.CreateInstance(Variables[op]);
                if (operatorNodeObject is OperatorNode)
                {
                    return (OperatorNode)operatorNodeObject;
                }

                throw new Exception("Unhandled operator");
            }

            return null;
        }

        /// <summary>
        /// Gets the precedence of the of the operator.
        /// </summary>
        /// <param name="op">Op.</param>
        /// <returns>The precedence of the given operator.</returns>
        public static ushort GetPrecedence(char op)
        {
            ushort precedenceValue = 0;
            if (Variables.ContainsKey(op))
            {
                Type type = Variables[op];
                PropertyInfo propertyInfo = type.GetProperty("Precedence");
                if (propertyInfo != null)
                {
                    object propertyValue = propertyInfo.GetValue(type);
                    if (propertyValue is ushort)
                    {
                        precedenceValue = (ushort)propertyValue;
                    }
                }
            }

            return precedenceValue;
        }
    }
}