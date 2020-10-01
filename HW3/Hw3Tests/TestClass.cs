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
        public void TestFibReadline()
        {
            FibonacciTextReader tr = new FibonacciTextReader(1);
            string output = tr.ReadLine();
            Assert.That(output, Is.EqualTo("1"));
        }

        [Test]
        public void TestFibReadlineForNegativeMaxValue()
        {
            FibonacciTextReader tr = new FibonacciTextReader(-2);
            Assert.AreEqual(null, tr.ReadLine());
        }

        [Test]
        public void TestFibReadLine()
        {
            FibonacciTextReader tr= new FibonacciTextReader(7);
            //tr.MaxValue = 7;
            Assert.AreEqual("0", "1", "1", "2", "3", "5", "8", tr.ReadLine());


        }


    }
}
