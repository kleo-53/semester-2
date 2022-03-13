using System;
using NUnit.Framework;
using StackCalculator;

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
            Assert.Pass();
        }

        [Test]
        public void PopTest()
        {
            var stack = new StackOnArray();
            stack.Push(1);
            var result = stack.Pop();
            Assert.AreEqual(1, result);
        }

    }
}