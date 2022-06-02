namespace PriorityQueue.Tests;

using PriorityQueue;
using NUnit.Framework;

public class Tests
{
    [Test]
    public void FirstInFirstOutTest()
    {
        var queue = new MyPriorityQueue<int>();
        queue.Enqueue(1, 32);
        queue.Enqueue(100, 32);
        queue.Enqueue(2, 1);
        queue.Enqueue(100, 1);
        queue.Enqueue(2, 2);
        queue.Enqueue(1, 11);
        queue.Enqueue(100, 11);
        queue.Enqueue(100, -41);
        Assert.AreEqual(32, queue.Dequeue());
        Assert.AreEqual(1, queue.Dequeue());
        Assert.AreEqual(11, queue.Dequeue());
        Assert.AreEqual(-41, queue.Dequeue());
        Assert.AreEqual(1, queue.Dequeue());
        Assert.AreEqual(2, queue.Dequeue());
        Assert.AreEqual(32, queue.Dequeue());
        Assert.AreEqual(11, queue.Dequeue());
        Assert.IsTrue(queue.Empty);
    }

    [Test]
    public void DeleteFromEmptyPriorityQueue()
    {
        var queue = new MyPriorityQueue<int>();
        Assert.Throws<EmptyPriorityQueueException>(() => queue.Dequeue());
        queue.Enqueue(2, 2);
        Assert.AreEqual(2, queue.Dequeue());
        Assert.Throws<EmptyPriorityQueueException>(() => queue.Dequeue());

    }

    [Test]
    public void EmptyWorkTest()
    {
        var queue = new MyPriorityQueue<int>();
        Assert.IsTrue(queue.Empty);
        queue.Enqueue(1, 32);
        Assert.IsFalse(queue.Empty);
        queue.Dequeue();
        Assert.IsTrue(queue.Empty);
    }

    [Test]
    public void CorrectNegativePriorityTest()
    {
        var queue = new MyPriorityQueue<int>();
        queue.Enqueue(-1, 32);
        queue.Enqueue(-2, 1);
        queue.Enqueue(-1, 11);
        queue.Enqueue(-2, 2);
        queue.Enqueue(0, 0);
        Assert.AreEqual(0, queue.Dequeue());
        Assert.AreEqual(32, queue.Dequeue());
        Assert.AreEqual(11, queue.Dequeue());
        Assert.AreEqual(1, queue.Dequeue());
        Assert.AreEqual(2, queue.Dequeue());
        Assert.IsTrue(queue.Empty);
    }

    [Test]
    public void PriorityWithStringValuesTest()
    {
        var queue = new MyPriorityQueue<string>();
        queue.Enqueue(1, "32");
        queue.Enqueue(-34, "1");
        Assert.AreEqual("32", queue.Dequeue());
        Assert.AreEqual("1", queue.Dequeue());
        Assert.IsTrue(queue.Empty);
    }

    [Test]
    public void PriorityWithCharValuesTest()
    {
        var queue = new MyPriorityQueue<char>();
        queue.Enqueue(100500, '#');
        queue.Enqueue(1, '1');
        Assert.AreEqual('#', queue.Dequeue());
        Assert.AreEqual('1', queue.Dequeue());
        Assert.IsTrue(queue.Empty);
    }
}
