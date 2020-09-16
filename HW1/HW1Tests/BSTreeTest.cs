using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HW1;
using NUnit.Framework.Interfaces;

namespace HW1Tests
{
    [TestFixture]
    class BSTreeTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]

        public void TestInsert()
        {
            //Arrange
            BSTNode root = null;
            BSTree tree = new BSTree();

            int[] myNumber = { 23, 45, 20, 12 };
            foreach (int number in myNumber)
            {   //Act
                root = tree.insert(root, number);
            }
            //Assert
            Assert.AreEqual(23, root.data);
            Assert.AreEqual(20, root.left.data);
            Assert.AreEqual(45, root.right.data);
            Assert.AreEqual(12, root.left.data);
            int numberOfNodes = tree.countNumberOfNodes(root);
            Assert.AreEqual(4, numberOfNodes);
            int level = tree.countNumberOflevels(root);
            Assert.AreEqual(3, level);
        }


    }
}

