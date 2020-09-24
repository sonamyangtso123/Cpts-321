// <copyright file="TestClass.cs" company="Sonam yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Homework2Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Homework2;
    using NUnit.Framework;

    /// <summary>
    /// this is a test class for distinct integer count methods.
    /// </summary>
    [TestFixture]
    public class TestClass
    {
        /// <summary>
        /// This method test the CountDistinctIntegersUsingHash method, which count the number of distinct
        /// integers in array using hashset.
        /// </summary>
        [Test]
        public void TestCountDistinctIntegersUsingHash()
        {
            int[] array = new int[] { 1, 4, 6, 8, 5, 5, 6, 7, 8, 6 };
            int distinctIntegerCount = Finder.CountDistinctIntegersUsingHash(array);
            Assert.That(distinctIntegerCount, Is.EqualTo(6));
        }

        /// <summary>
        /// This method test the CountDistinctIntegerByStorage method,which counts the number of distinct integers
        /// in an array by O(1) space complexity.
        /// </summary>
        [Test]
        public void TestCountDistinctIntegerByStorage()
        {
            int[] array = new int[] { 1, 6, 9, 0, 6, 8, 0, 9 };
            int uniqueCount = Finder.CountDistinctIntegerByStorage(array);
            Assert.That(uniqueCount, Is.EqualTo(5));
        }

        /// <summary>
        /// This method test the CountDistinctIntegerByStorage method,which counts the number of distinct integers
        /// in an array by O(1) space complexity when there is only two same elements.
        /// </summary>
        [Test]
        public void TestCountDistinctIntegerByStorageOfTwoSameIntegers()
        {
            int[] array = new int[] { 2, 2 };
            int uniqueCount = Finder.CountDistinctIntegerByStorage(array);
            Assert.That(uniqueCount, Is.EqualTo(1));
        }

        /// <summary>
        /// This method test the CountDistinctIntegerByStorage method,which counts the number of distinct integers
        /// in an array by O(1) space complexity when an array is empty.
        /// </summary>
        [Test]
        public void TestCountDistinctIntegerByStorageForEmptyArray()
        {
            int[] array = new int[] { };
            int uniqueCount = Finder.CountDistinctIntegerByStorage(array);
            Assert.That(uniqueCount, Is.EqualTo(0));
        }

        /// <summary>
        /// This method test the CountDistinctIntegerBySort method,which counts the number of distinct integers
        /// in an array by using build in sort method.
        /// </summary>
        [Test]
        public void TestCountDistinctIntegerBySort()
        {
            int[] array = new int[] { 1, 3, 4, 3, 4, 5, 6, 6, 4, 6, 6, 5 };
            int distinctCount = Finder.CountDistinctIntegerBySort(array);
            Assert.That(distinctCount, Is.EqualTo(5));
        }

        /// <summary>
        /// This method test the CountDistinctIntegerBySort method,which counts the number of distinct integers
        /// in an array by using build in sort method whe there is ni duplicates element presents.
        /// </summary>
        [Test]
        public void TestCountDistinctIntegerBySortWhenNoDuplicates()
        {
            int[] arry = new int[] { 1, 3, 5, 6, 7 };
            int distinctCount = Finder.CountDistinctIntegerBySort(arry);
            Assert.That(distinctCount, Is.EqualTo(5));
        }

        /// <summary>
        /// This method test the CountDistinctIntegerBySort method,which counts the number of distinct integers
        /// in an array by using build in sort method for empty array.
        /// </summary>
        [Test]
        public void TestCountDistnctIntegerBySortForEmptyArray()
        {
            int[] array = new int[] { };
            int distinctCount = Finder.CountDistinctIntegerBySort(array);
            Assert.That(distinctCount, Is.EqualTo(0));
        }
    }
}
