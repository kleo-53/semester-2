using NUnit.Framework;
using StackCalculator;

namespace stackCalculator.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            IStack stack = new StackOnArray();
        }

        /// <summary>
        /// �������� ������� ���������� �������� � ����� �� �������
        /// </summary>
        [Test]
        public void PushToAtackOnArrayTest()
        {
            var stack = new StackOnArray();
            Assert.IsTrue(stack.IsEmpty);
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty);
        }

        /// <summary>
        /// �������� ������� ���������� �������� � ����� �� ������
        /// </summary>
        [Test]
        public void PushToAtackOnAListTest()
        {
            var stack = new StackOnList();
            Assert.IsTrue(stack.IsEmpty);
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty);
        }

        /// <summary>
        /// �������� ������� �������� ���� ��������� �� ����� �� �������
        /// </summary>
        [Test]
        public void PopTestWithTwoElementsFromStackOnArray()
        {
            var stack = new StackOnArray();
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
        }

        /// <summary>
        /// �������� ������� �������� ���� ��������� �� ����� �� ������
        /// </summary>
        [Test]
        public void PopTestWithTwoElementsFromStackOnList()
        {
            var stack = new StackOnList();
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
        }
        [Test]
        public void PopTestWithNoPush()
        {
            var stack = new StackOnList();
            Assert.AreEqual(null, stack.Pop());
        }

    }
}