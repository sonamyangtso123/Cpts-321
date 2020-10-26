// <copyright file="Program.cs" company="P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;

namespace CptS321
{
    /// <summary>
    /// console class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// this is a main method which has direct interaction  with the user.
        /// </summary>
        /// <param name="args"> args.</param>
        public static void Main(string[] args)
        {
            string expression = "x+y";

            // create an instance of ExpressionTree class.
            ExpressionTree tree = new ExpressionTree(expression);

            // set varname and varVal to empty.
            string varName = string.Empty;
            string varVal = string.Empty;
            do
            {
                Console.WriteLine("Menu (current expression =" + tree.InFix + ")");
                MenuOption();
                string userInput = Console.ReadLine();
                Console.WriteLine();
                switch (userInput)
                {
                    case "1":
                        // get a new expression and display the new expression
                        Console.WriteLine("Enter new epression: ");
                        tree = new ExpressionTree(Console.ReadLine());
                        break;

                    case "2":
                        // reads the vraible name and varible value.
                        Console.WriteLine("Enter variable name:");
                        varName = Console.ReadLine();
                        Console.WriteLine("Enter variable value:");
                        string varValue = Console.ReadLine();

                        // if variable name is in the dictionary set new value to that otherwise add variable 
                        // name and value pair in the dictionary
                        tree.SetVariable(varName, Convert.ToDouble(varValue));
                        break;

                    case "3":
                        // evaluate the result of the expression.
                        Console.WriteLine(tree.Evaluate());
                        break;

                    case "4":
                        System.Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again");
                        break;
                }
            }
            while (true);
        }

        private static void MenuOption()
        {
            Console.WriteLine("1 = Enter a new expression");
            Console.WriteLine("2 = Set a variable value");
            Console.WriteLine("3 = Evaluate tree");
            Console.WriteLine("4 = Quit");
        }
    }
}
