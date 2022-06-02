namespace SkipList.Tests;

using NUnit.Framework;

public class Tests
{

    [Test]
    public void CountTest()
    {
        MySkipList<int> list = new();
        Assert.AreEqual(0, list.Count);
        list.Add(2);
        Assert.AreEqual(1, list.Count);
        list.Add(-54);
        Assert.AreEqual(2, list.Count);
        list.Remove(2);
        Assert.AreEqual(1, list.Count);
        list.Remove(2);
        Assert.AreEqual(1, list.Count);
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}
