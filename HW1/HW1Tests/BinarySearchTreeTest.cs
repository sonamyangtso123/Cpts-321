// <copyright file="BinarySearchTreeTest.cs" company="SonamCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author> Sonam yangtso</author>
// <WSUID> 11689463</WSUID>

namespace HW1Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AbtractDataStructure;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;

    /// <summary>
    /// BinarySearchTreeTest class test the methods of BinarySearchTree class.
    /// </summary>
    [TestFixture]
    internal class BinarySearchTreeTest
    {
        /// <summary>
        /// Setup function that starts the tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// TestInsert method test the some of the BInarySearchTree class methods.
        /// </summary>
        [Test]

        public void TestInsert()
        {
        // Arrange
            BinarySearchTree tree = new BinarySearchTree();

            int[] myNumber = { 23, 45, 20, 12 };
            foreach (int number in myNumber)
            { // Act
                tree.Insert(number);
            }

            // Assert
            Assert.AreEqual(23, tree.Root.Data);
            Assert.AreEqual(20, tree.Root.Left.Data);

            Assert.AreEqual(45, tree.Root.Right.Data);
            Assert.AreEqual(12, tree.Root.Left.Left.Data);

            // testing CountNumberOfNodes method
            int numberOfNodes = tree.CountNumberOfNodes();
            Assert.AreEqual(4, numberOfNodes);

            // testing CountNumberOfLevels method.
            int level = tree.CountNumberOflevels();
            Assert.AreEqual(3, level);
        }

        /// <summary>
        /// this test method is testing edge case when the tree is empty.
        /// </summary>
        [Test]
        public void TestCountNumberOflevelsWhenRootNullReturnsZero()
        {
             BinarySearchTree tree2 = new BinarySearchTree();
             Assert.AreEqual(0, tree2.CountNumberOflevels());
        }

        /// <summary>
        /// this test case is testing CountNumberofNodes when user pass duplicates intergers.
        /// </summary>
        [Test]
        public void TestCountNumberOfNodesWhenDuplicatesEntry()
        {
            BinarySearchTree tree3 = new BinarySearchTree();
            int[] number = { 20, 18, 17, 24, 25, 24 };
            foreach (int num in number)
            {
                tree3.Insert(num);
            }

            Assert.AreEqual(5, tree3.CountNumberOfNodes());
        }
    }
}