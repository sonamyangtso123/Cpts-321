// <copyright file="Program.cs" company="sonam's company">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author> Sonam yangtso </author>
// <WSUID> 1189463</WSUID>

namespace HW1
{
    using System;
    using AbtractDataStructure;

    /// <summary>
    /// main Program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args"> string arrays arguments.</param>
        public static void Main(string[] args)
        {
            // create an instance of BinarySearchTree
            BinarySearchTree tree = new BinarySearchTree();

            // promt user interface
            Console.WriteLine("Enter a list of numbers in the range [0,100] with spaces: ");

            // read user inputs and save into a string variable inputNumbers
            string inputNumbers = Console.ReadLine();

            // split inputNumbers by using delimeter space and save into an array
            string[] numbers = inputNumbers.Split(' ');

            // interate through each string number in an array of string numbers
            foreach (string num in numbers)
            {
                try
                {
                    // convert the string num to interger value
                    int result = int.Parse(num);

                    // insert into binary search tree using Insert method
                    tree.Insert(result);
                }

                // if user input is not an string number the thro
                catch (FormatException)
                {
                    Console.WriteLine("Unable to parse '{num}'");
                }
            }

            // prints out binary search tree datas in an increeasing order
            Console.Write("Tree contents : ");
            tree.InOderTraverse();
            Console.WriteLine();

            // method calls to get number of nodes
            int numberOfNodes = tree.CountNumberOfNodes();

            // method call to get height of tree
            int numberOfLevels = tree.CountNumberOflevels();

            Console.WriteLine("Tree statistics:");
            Console.WriteLine(" number of nodes: " + numberOfNodes);
            Console.WriteLine(" number of levels: " + numberOfLevels);

            // calculate the minimum height of a tree
            double minimumLevels = Math.Floor(Math.Log2(numberOfNodes) + 1);
            Console.WriteLine(" Minimum levels of a tree with " + numberOfNodes + " nodes could have: " + minimumLevels);
            Console.WriteLine("Done");
        }
    }
}
