// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Homework2;

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
        public void TestCountDistinctIntegerByStorageComplexity()
        {
            int[] array = new int[] {1};
            int uniqueCount = Finder.CountDistinctIntegerByStorageComplexity(array);
            Assert.That(uniqueCount, Is.EqualTo(1));
        }
    }
}
