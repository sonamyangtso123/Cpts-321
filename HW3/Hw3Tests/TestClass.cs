// Sonam Yangtso 11689463
// <copyright file="TestClass.cs" company="WSU">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
namespace HW3Tests
{
    using HW3;
    using NUnit.Framework;

    [TestFixture]
    public class TestClass
    {
        // testing FibonacciTextReader override ReadLine method when maxValue is 0
        [Test]
        public void TestFibReadLineFor0()
        {
            FibonacciTextReader tr = new FibonacciTextReader(0);
            string output = tr.ReadLine();
            Assert.AreEqual("0", output);
        }

        // testing FibonacciTextReader override readLine method when maxValue is less than 0
        [Test]
        public void TestFibReadLineForNegativeMaxValue()
        {
            FibonacciTextReader tr = new FibonacciTextReader(-2);
            Assert.AreEqual(null, tr.ReadLine());
        }

        // testing FibonacciTextReader override readLine method when maxValue is 3
        [Test]
        public void TestFibReadLineFor3()
        {
            FibonacciTextReader tr = new FibonacciTextReader(3);
            Assert.AreEqual("0", tr.ReadLine());
            Assert.AreEqual("1", tr.ReadLine());
            Assert.AreEqual("1", tr.ReadLine());
        }
    }
}
