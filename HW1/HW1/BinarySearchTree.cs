// <copyright file="BinarySearchTree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author> Sonam Yangtso</author>
// <WSUID> 11689463 </WSUID>

namespace AbtractDataStructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is a BinarySearchTree class and it has Insert, CountNumberOfNodes.
    /// CountNumberOfLevels and InorderTraverse methods.
    /// </summary>
    public class BinarySearchTree
    {
        /// <summary>
        /// private field root.
        /// </summary>
        private BSTNode overAllRoot;

        /// <summary>
        /// Gets or sets for overAllRoot field.
        /// </summary>
        public BSTNode Root
        {
            get { return this.overAllRoot; }
            set { this.overAllRoot = value; }
        }

        /// <summary>
        /// Insert method inserts a node with unique integer data to binary search tree.
        /// Insert number to left if number is less than current root data and otherwise to right.
        /// </summary>
        /// <param name="number">Parameter int number.</param>
        public void Insert(int number)
        {
            this.overAllRoot = this.Insert(this.overAllRoot, number);
        }

         /// <summary>
         /// This methods counts the number of nodes in a binary search tree.
         /// </summary>
         /// <returns>number of nodes in a tree.</returns>
        public int CountNumberOfNodes()
        {
            return this.CountNumberOfNodes(this.overAllRoot);
        }

        /// <summary>
        /// This methods counts the height of a binary search tree.
        /// </summary>
        /// <returns> height of a tree.</returns>
        public int CountNumberOflevels()
        {
            return this.CountNumberOflevels(this.overAllRoot);
        }

        /// <summary>
        /// This method prints out the data from each nodes of tree in inceasing order.
        /// </summary>
        public void InOderTraverse()
        {
            this.InOderTraverse(this.overAllRoot);
        }

        /// <summary>
        /// this is a private insert method.
        /// </summary>
        /// <param name="node">BST node.</param>
        /// <param name="number">int number.</param>
        /// <returns>node.</returns>
        private BSTNode Insert(BSTNode node, int number)
        {
            if (node == null)
            {
                node = new BSTNode(number);
            }
            else if (number > node.Data)
            {
                node.Right = this.Insert(node.Right, number);
            }
            else if (number < node.Data)
            {
                node.Left = this.Insert(node.Left, number);
            }

            return node;
        }

        private int CountNumberOfNodes(BSTNode root)
        {
            if (root != null)
            {
                // count all the left nodes plus all the right nodes plus 1 node for main root node
                return this.CountNumberOfNodes(root.Left) + this.CountNumberOfNodes(root.Right) + 1;
            }
            else
            {
                // if the tree is empty it returns 0
                return 0;
            }
        }

        private int CountNumberOflevels(BSTNode root)
        {
            if (root != null)
            {
                // Math function max will return the maximum levels from left subtree or right subtree.
                return 1 + Math.Max(this.CountNumberOflevels(root.Left), this.CountNumberOflevels(root.Right));
            }
            else
            {
            return 0;
            }
        }

        private void InOderTraverse(BSTNode root)
        {
            if (root == null)
            {
                return;
            }

            // traverse the tree to the left leave node
            this.InOderTraverse(root.Left);
            Console.Write(" " + root.Data);
            this.InOderTraverse(root.Right);
        }
    }
}