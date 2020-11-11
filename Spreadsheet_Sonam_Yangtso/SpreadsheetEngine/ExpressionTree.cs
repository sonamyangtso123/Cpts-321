// <copyright file="ExpressionTree.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Remoting.Messaging;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This is a ExpressionTree class. This class converts an expression to a tree and does all the mathematical
    /// calculation.
    /// </summary>
    public class ExpressionTree
    {
        private Dictionary<string, double> variables = new Dictionary<string, double>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// constructor that takes expression as an argument.
        /// </summary>
        /// <param name="expression"> input expression.</param>
        public ExpressionTree(string expression)
        {
            this.InFixExpression = expression;

            this.Root = this.BuildExpressionTree(expression);
        }

        /// <summary>
        /// Gets the variable value pairs from the dictionary Variable.
        /// </summary>
        public Dictionary<string, double> Variables
        {
            get { return this.variables; }
        }

        /// <summary>
        /// Gets or sets the user expression from ExpressionTree constructor.
        /// </summary>
        public string InFixExpression { get; set; }

        /// <summary>
        /// Gets or sets the root .
        /// </summary>
        public ExpressionTreeNode Root { get; set; }

        /// <summary>
        /// this method set a value to a varibale in the Variable dictionary.
        /// </summary>
        /// <param name="variableName"> varible Name.</param>
        /// <param name="variableValue"> value corresponding to variable name.</param>
        public void SetVariable(string variableName, double variableValue)
        {
            this.Variables[variableName] = variableValue;
        }

        /// <summary>
        ///  This method evaluate the given expression by first converting the expression to a postfix expression
        ///  and then build the postfix expression to a Tree.
        /// </summary>
        /// <returns> the evaluated value or 0.0  if Root is null.</returns>
        public double Evaluate()
        {
            if (this.Root != null)
            {
                ExpressionTreeNode root = this.Root;
                return root.Evaluate(ref this.variables);
            }

            // if the root is empty.
            return 0.0;
        }

        /// <summary>
        /// This method calls ConvertToPostFix method which converts the user expression into an postfix
        /// expression and then builds an expression tree.
        /// </summary>
        private ExpressionTreeNode BuildExpressionTree(string expression)
        {
            // Check whether given expression is null.
            if (string.IsNullOrEmpty(expression))
            {
                return null;
            }
            else
            {
                // Send the expression to evaluate as infix to postfix convert function.
                List<ExpressionTreeNode> postfixNodes = this.ConvertToPostfix(expression);
                Stack<ExpressionTreeNode> operandStack = new Stack<ExpressionTreeNode>();
                foreach (ExpressionTreeNode node in postfixNodes)
                {
                    if (node is ConstantNode)
                    {
                        operandStack.Push(node);
                    }
                    else if (node is VariableNode)
                    {
                        operandStack.Push(node);
                        //if (variables.ContainsKey(((VariableNode)node).Name)){
                        //    SetVariable(((VariableNode)node).Name, ((VariableNode)node).Value);
                        //}
                        //else
                        //{
                        //    throw new Exception("dfha");
                        //}
                        this.variables.Add(((VariableNode)node).Name, 0); // Variable values set to 0 by default
                    }
                    else
                    {
                        ((OperatorNode)node).Left = operandStack.Pop();
                        ((OperatorNode)node).Right = operandStack.Pop();
                        operandStack.Push(node);
                    }
                }

                return operandStack.Pop();
            }
        }

        /// < summary >
        /// This method converts the user expression to a postfix expression.
        /// </summary>
        /// <returns> a list of string . </returns>
        private List<ExpressionTreeNode> ConvertToPostfix(string expression)
        {
            List<ExpressionTreeNode> postfixResult = new List<ExpressionTreeNode>();
            Stack<ExpressionTreeNode> operatorStack = new Stack<ExpressionTreeNode>();
            ExpressionTreeNode tempNode;
            int i = 0;
            string tempName = string.Empty;

            // Check for a negative as the first symbol
            if (expression[i] == '-')
            {
                tempName += '-';
                i++;
            }

            // Separate expression into constant nodes, variable nodes, and operatornodes
            while (i < expression.Length)
            {
                while (i < expression.Length && !this.IsOperator(expression[i]))
                {
                    tempName += expression[i];
                    i++;
                }

                if (tempName == string.Empty)
                {
                    if (i < expression.Length)
                    {
                        tempName = expression[i].ToString();    // next operator
                    }
                }

                tempNode = this.CreateNode(tempName);
                if (tempNode is VariableNode || tempNode is ConstantNode)
                {
                    postfixResult.Add(tempNode);
                    tempName = string.Empty;
                }
                else if (tempNode is OperatorNode)
                {
                    if (tempNode is LeftParentheses)
                    {
                        operatorStack.Push(tempNode);
                        tempName = string.Empty;
                        i++;
                    }
                    else if (tempNode is RightParentheses)
                    {
                        while (!(operatorStack.Peek() is LeftParentheses))
                        {
                            postfixResult.Add(operatorStack.Pop());
                        }

                        operatorStack.Pop();
                        tempName = string.Empty;
                        i++;
                    }
                    else
                    {
                        // Check the precedence of operators.
                        while (operatorStack.Count > 0 && ((OperatorNode)tempNode).Precedence <= ((OperatorNode)operatorStack.Peek()).Precedence)
                        {
                            postfixResult.Add(operatorStack.Pop());
                        }

                        operatorStack.Push(tempNode);
                        tempName = string.Empty;
                        i++;

                        if (expression[i] == '-')
                        {
                            tempName += '-';
                            i++;
                        }
                    }
                }
            }

            while (operatorStack.Count > 0)
            {
                postfixResult.Add(operatorStack.Pop());
            }

            return postfixResult;
        }

        /// <summary>
        /// This method checks the incoming character is an operator node present in the dictionary Variables in
        /// the OperatorNodeFactory.
        /// </summary>
        /// <param name="op"> is an operator.</param>
        /// <returns> true if it is a operator node.</returns>
        private bool IsOperator(char op)
        {
            return OperatorNodeFactory.Variables.ContainsKey(op);
        }

        /// <summary>
        /// create a nod.
        /// </summary>
        /// <param name="name"> name.</param>
        /// <returns> node .</returns>
        private ExpressionTreeNode CreateNode(string name)
        {

            if ((name[0] >= 48 && name[0] <= 57) || (name.Length > 1 && name[0] == '-'))
            {
                /* First character is a number: Constant Node */
                if (int.TryParse(name, out int value))
                {
                    return new ConstantNode(value);
                }
                else
                {
                    return null;
                }
            }
            else if (name.Length == 1 && this.IsOperator(name[0]))
            {
                /* Operator Node */
                return OperatorNodeFactory.CreateNewNode(name[0]);
            }
            else
            {
                /* Variable Node */
                return new VariableNode(name);
            }
        }

        /// <summary>
        /// This method get alllthe variable name from the variables dictionary and save into a list.
        /// </summary>
        /// <returns> a list of variable name.</returns>
        public List<string> GetVariableName()
        {
            List<string> variableName = new List<string>();
            foreach (string name in this.Variables.Keys)
            {
                variableName.Add(name);
            }

            return variableName;
        }
    }
}
