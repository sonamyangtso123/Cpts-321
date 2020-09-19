// <copyright file="BSTNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace AbtractDataStructure
{
    /// <summary>
    /// This is node class with three private feilds: data,left node and right node.
    /// </summary>
    public class BSTNode
    {
        /// <summary>
        /// initializing integer data type member.
        /// </summary>
        private int data;

        /// <summary>
        /// initializing left node pointer.
        /// </summary>
        private BSTNode left;

        /// <summary>
        ///  initailzing right node pointer.
        /// </summary>
        private BSTNode right;

        /// <summary>
        /// Initializes a new instance of the <see cref="BSTNode"/> class.
        /// </summary>
        /// <param name="data">Parameter int data.</param>
        public BSTNode(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }

        /// <summary>
        /// Gets or sets for int data member.
        /// </summary>
        public int Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        /// <summary>
        /// Gets or sets for left node pointer.
        /// </summary>
        public BSTNode Left
        {
            get { return this.left; }
            set { this.left = value; }
        }

        /// <summary>
        /// Gets or sets for right node poiner.
        /// </summary>
        public BSTNode Right
        {
            get { return this.right; }
            set { this.right = value; }
        }
    }
}