/// < copyright file = "ExpressionTree.cs" company = "Sonam Yangtso" >
/// Copyright(c) PlaceholderCompany.All rights reserved.
/// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExpressionTree
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// constructor that takes expression as an argument.
        /// </summary>
        /// <param name="expression"> input expression.</param>
        public ExpressionTree(string expression)
        {
            this.InFix = expression;
            this.Variables = new Dictionary<string, double>();
            
            this.ConstructTheTree();
        }

        public Dictionary<string, double> Variables { get; set; }


        /// <summary>
        /// Gets or sets and Sets the Expression from ExpressionTree constructor.
        /// </summary>
        public string InFix { get; set; }

        public string PostFix { get; set; }

        private OperatorNode Root { get; set; }



        private bool isOperator(char op)
        {
            return OperatorNodeFactory.Variables.ContainsKey(op);
        }
        

        public void SetVariable(string name, double value)
        {
            this.Variables[name] = value;
        }

        public double Evaluate()
        {

            this.ConstructTheTree();
            // Root of the tree should be an operator.
            if (this.Root != null)
            {
                OperatorNode root = this.Root;
                return root.Evaluate();
            }

            // Nothing to evaluate
            return 0.0;
        }

        private void ConstructTheTree()
        {
            Stack<ExpressionTreeNode> operators = new Stack<ExpressionTreeNode>();
            ExpressionTreeNode newNode;

            // Compile the tree to find post fix function.
            this.ConvertToPostFix();

            // Then evaluate the function.
            foreach (var item in this.PostFix.Split(' '))
            {
                // token is a constant value
                if (item != string.Empty)
                {

                    if (double.TryParse(item, out double d))
                    {
                        newNode = new ConstantNode(double.Parse(item));
                    }

                    // Check whether item is a variable 
                    else if (this.Variables.Keys.Contains(item))
                    {
                        newNode = new VariableNode(item, this.Variables[item]);
                    }

                    // if the incoming item is an OperatorNode
                    else if (OperatorNodeFactory.Variables.ContainsKey(item[0]))
                    {
                        newNode = OperatorNodeFactory.CreateNewNode(item[0]);
                        ((OperatorNode)newNode).Left = operators.Pop();
                        ((OperatorNode)newNode).Right = operators.Pop();
                    }
                    else
                    {
                        newNode = null;
                    }

                    operators.Push(newNode);
                }
            }

            try
            {
                this.Root = operators.Pop() as OperatorNode;
            }
            catch (Exception)
            {
                throw new Exception("Not an operator.");
            }
        }




        private void ConvertToPostFix()
        {
            Stack<string> opStack = new Stack<string>();
            List<string> output = new List<string>();
            for (int i = 0; i < this.InFix.Length; i++)
            {
                char sub = this.InFix[i];
                if (char.IsDigit(sub))
                {
                    string digit = string.Empty;
                    while (i < this.InFix.Length && char.IsDigit(sub))
                    {
                        digit += sub;
                        i++;
                        if (i < this.InFix.Length)
                        {
                            sub = this.InFix[i];
                        }
                    }

                    output.Add(digit + " ");
                    i--;
                }
                else if (sub == '(')
                {
                    opStack.Push(sub.ToString());
                }
                else if (sub == ')')
                {
                    string operand = opStack.Pop();
                    while (opStack.Count > 0 && (operand != "("))
                    {
                        output.Add(operand);
                        operand = opStack.Pop();
                    }

                    if (operand != "(")
                    {
                        throw new ArgumentException("No matching left parenthesis.");
                    }
                }
                else if (this.isOperator(sub))
                {
                    OperatorNode currentNode  = OperatorNodeFactory.CreateNewNode(sub);
                    while (opStack.Count > 0 && this.isOperator(char.Parse(opStack.Peek())))
                    {

                        OperatorNode newNode = OperatorNodeFactory.CreateNewNode(char.Parse(opStack.Peek()));


                        if (newNode.Precedence >= currentNode.Precedence)
                        {
                            output.Add(opStack.Pop());
                        }
                        else
                        {
                            break;
                        }
 
                    }

                    opStack.Push(sub.ToString());
                }

                else
                {
                    string variableNameBuilder = string.Empty;
                    while (!OperatorNodeFactory.Variables.ContainsKey(sub) && i < this.InFix.Length)
                    {
                        variableNameBuilder += sub;
                        i++;
                        if (i < this.InFix.Length)
                        {
                            sub = this.InFix[i];
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


            while (opStack.Count > 0)
            {
                var top = opStack.Pop();
                output.Add(top);
            }

            this.PostFix = string.Join(" ", output);
        }
    }
}