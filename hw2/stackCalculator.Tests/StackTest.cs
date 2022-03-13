using NUnit.Framework;
using stackCalculator;

namespace stackCalculator.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PushTest()
        {
            var stack = new StackOnArray();
            Assert.IsTrue(stack.IsEmpty());
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
        }

    }
}