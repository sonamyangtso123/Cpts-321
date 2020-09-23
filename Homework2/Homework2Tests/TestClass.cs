// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Homework2;
using System;

namespace Homework2Tests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestCountDistinctIntegersUsingHash()
        {
            int[] array = new int[] { 1, 4, 6, 8, 5, 5, 6, 7, 8, 6 };
            int distinctIntegerCount = Finder.CountDistinctIntegersUsingHash(array);
            Assert.That(distinctIntegerCount, Is.EqualTo(6));
        }

        [Test]
        public void TestCountDistinctIntegerByStorage()
        {
            int[] array = new int[] {1,6,9,0,6,8,0,9};
            int uniqueCount = Finder.CountDistinctIntegerByStorage(array);
            Assert.That(uniqueCount, Is.EqualTo(5));
        }

        [Test]
        public void TestCountDistinctIntegerByStorageOfTwoSameIntegers()
        {
            int[] array = new int[] { 2, 2 };
            int uniqueCount = Finder.CountDistinctIntegerByStorage(array);
            Assert.That(uniqueCount, Is.EqualTo(1));

        }

        [Test]
        public void TestCountDistinctIntegerBySort()
        {
            int[] array = new int[] { 1, 3, 4, 3, 4, 5, 6, 6, 4, 6, 6, 5 };
            
            int distinctCount = Finder.CountDistinctIntegerBySort(array);
            Assert.That(distinctCount, Is.EqualTo(5));
        }
    }
}
