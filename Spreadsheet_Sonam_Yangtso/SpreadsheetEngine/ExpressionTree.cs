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
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// constructor that takes expression as an argument.
        /// </summary>
        /// <param name="expression"> input expression.</param>
        public ExpressionTree(string expression)
        {
            this.InFixExpression = expression;
            this.Variables = new Dictionary<string, double>();
        }

        /// <summary>
        /// Gets or sets the variable value pairs from the dictionary Variable.
        /// </summary>
        public Dictionary<string, double> Variables { get; set; }

        /// <summary>
        /// Gets or sets the user expression from ExpressionTree constructor.
        /// </summary>
        public string InFixExpression { get; set; }

        /// <summary>
        /// Gets or sets the root .
        /// </summary>
        public OperatorNode Root { get; set; }

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
            this.BuildExpressionTree();

            if (this.Root != null)
            {
                OperatorNode root = this.Root;
                return root.Evaluate();
            }

            // if the root is empty.
            return 0.0;
        }

        /// <summary>
        /// This method calls ConvertToPostFix method which converts the user expression into an postfix
        /// expression and then builds an expression tree.
        /// </summary>
        private void BuildExpressionTree()
        {
            Stack<ExpressionTreeNode> nodes = new Stack<ExpressionTreeNode>();

            // calls ConvertToPostFix method
            List<string> postFix = this.ConvertToPostFix();

            // iterate each element in postFix
            foreach (string item in postFix)
            {
                // If the item is a constant then call the constant node.
                if (double.TryParse(item, out double result))
                {
                    ExpressionTreeNode newNode = new ConstantNode(result);
                    nodes.Push(newNode);
                }

                // Check whether item is a variable.
                else if (this.Variables.Keys.Contains(item))
                {
                    ExpressionTreeNode newNode = new VariableNode(item, this.Variables[item]);
                    nodes.Push(newNode);
                }

                // if the incoming item is an OperatorNode
                else if (this.IsOperator(char.Parse(item)))
                {
                    ExpressionTreeNode newNode = OperatorNodeFactory.CreateNewNode(char.Parse(item));
                    ((OperatorNode)newNode).Left = nodes.Pop();
                    ((OperatorNode)newNode).Right = nodes.Pop();
                    nodes.Push(newNode);
                }
            }

            // save each node to Root.
            this.Root = nodes.Pop() as OperatorNode;
        }

        /// <summary>
        /// This method checks the incoming character is an operator node present in the dictionary Variables in
        /// the OperatorNodeFactory.
        /// </summary>
        /// <param name="op"> is an operator.</param>
        /// <returns> true if it is a operator node.</returns>
        public bool IsOperator(char op)
        {
            return OperatorNodeFactory.Variables.ContainsKey(op);
        }

        /// < summary >
        /// This method converts the user expression to a postfix expression.
        /// </summary>
        /// <returns> a list of string . </returns>
        private List<string> ConvertToPostFix()
        {

            Stack<string> opStack = new Stack<string>();
            List<string> output = new List<string>();
            for (int i = 0; i < this.InFixExpression.Length; i++)
            {

                char sub = this.InFixExpression[i];
                if (char.IsDigit(this.InFixExpression[i]))
                {
                    string digit = string.Empty;
                    while (char.IsDigit(sub) && i < this.InFixExpression.Length)
                    {
                        digit += sub;
                        i++;
                        if (i < this.InFixExpression.Length)
                        {
                            sub = this.InFixExpression[i];
                        }
                    }

                    output.Add(digit + " ");
                    i--;
                }

                // 2. If the incoming symbol is a left parentheses, push it on the stack.
                else if (sub == '(')
                {
                    opStack.Push(sub.ToString());
                }

                // 3. If the incoming symbol is a right parenthesis: discard the right parenthesis,
                //    pop and print the stack symbols until you see a left parenthesis.
                //    Pop the left parenthesis and discard it.
                else if (sub == ')')
                {
                    string operand = opStack.Pop();
                    while (opStack.Count > 0 && (operand != "("))
                    {
                        output.Add(operand);
                        operand = opStack.Pop();
                    }

                    // if you don't see a left parenthesis that pairs for right parenthesis
                    if (operand != "(")
                    {
                        throw new ArgumentException("No matching left parenthesis.");
                    }
                }

                // If the incoming symbol is an operator
                else if (this.IsOperator(sub))
                {
                    OperatorNode currentNode = OperatorNodeFactory.CreateNewNode(sub);

                    // If the incoming symbol is an operator and has either lower precedence than the operator on the top of the stack,
                    // or has the same precedence as the operator on the top of the stack then pop it and add to output list.
                    while (opStack.Count > 0 && this.IsOperator(char.Parse(opStack.Peek())))
                    {
                        OperatorNode stackNode = OperatorNodeFactory.CreateNewNode(char.Parse(opStack.Peek()));
                        if (currentNode.Precedence <= stackNode.Precedence)
                        {
                            output.Add(opStack.Pop());
                            //opStack.Push(sub.ToString());
                        }
                        else
                        {
                            break;
                        }
                    }

                    // If the incoming symbol is an operator and has either higher precedence than the operator on the top of the stack,
                    //  or has the same precedence as the operator on the top of the stack and push it on the stack.
                    opStack.Push(sub.ToString());

                }
                else
                {
                    string variableNameBuilder = string.Empty;
                    while (!OperatorNodeFactory.Variables.ContainsKey(sub) && i < this.InFixExpression.Length)
                    {
                        variableNameBuilder += sub;
                        i++;
                        if (i < this.InFixExpression.Length)
                        {
                            sub = this.InFixExpression[i];
                        }
                    }

                    output.Add(variableNameBuilder);

                    if (!this.Variables.ContainsKey(variableNameBuilder))
                    {
                        this.Variables.Add(variableNameBuilder, 0);
                    }

                    i--;
                }
            }

            // pop out all the operators in opStack stack and add to output list untill the stack get empty.
            while (opStack.Count > 0)
            {
                var top = opStack.Pop();
                output.Add(top);
            }

            // return the output list in postfix form expression.
            return output;
        }
    }
}