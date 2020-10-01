// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using HW3;


namespace HW3Tests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestFibReadLineFor0()
        {
            FibonacciTextReader tr = new FibonacciTextReader(0);
            string output = tr.ReadLine();
            Assert.AreEqual("0", output);
        }

        [Test]
        public void TestFibReadLineForNegativeMaxValue()
        {
            FibonacciTextReader tr = new FibonacciTextReader(-2);
            Assert.AreEqual(null, tr.ReadLine());
        }

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
