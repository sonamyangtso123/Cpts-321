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
        public void TestReadline()
        {
            FibonacciTextReader fibTest = new FibonacciTextReader(1);
            string output = fibTest.ReadLine();
            Assert.That(output, Is.EqualTo(1));
        }
    }
}
