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
        public static Dictionary<char, Type> Variables = new Dictionary<char, Type>
        {
            { '+', typeof(PlusOperatorNode) }, 
            { '-', typeof(MinusOperatorNode) },
            { '*', typeof(MultiplicationOperatorNode) },
            { '/', typeof(DivisionOperatorNode) },
        };

        //public OperatorNodeFactory()
        //{
        //}

        public static OperatorNode CreateNewNode(char character)
        {
            if (Variables.ContainsKey(character))
            {
                object operatorNodeObject = System.Activator.CreateInstance(Variables[character]);
                if (operatorNodeObject is OperatorNode)
                {
                    return (OperatorNode)operatorNodeObject;
                }

                throw new Exception("Unhandled exception");
            }

            return null;
        }
    }
}