using NUnit.Framework;
using System;
using UniqueList;

namespace UniqueList.Tests;

public class UListTest
{
    private UList list = new UList();

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddValueByCorrectPositionAndContainValueTest()
    {
        list.Add(1421);
        Assert.IsTrue(list.IsContain(1421));
        list.Add(-235, 1);
        list.Add(-4, 1);
        list.Add(346);
        Assert.IsTrue(list.IsContain(-235));
        Assert.IsFalse(list.IsContain(0));
    }

    [Test]
    public void AddValueByIncorrectPositionAndDoesNotContainValue()
    {
        Assert.Throws<OutOfListRangeException>(() => list.Add(34, 100));
        Assert.IsFalse(list.IsContain(34));
        Assert.Throws<OutOfListRangeException>(() => list.Add(45, -65));
        Assert.IsFalse(list.IsContain(45));
    }

    [Test]
    public void ChangeValueByIncorrectPosition()
    {
        Assert.Throws<OutOfListRangeException>(() => list.Change(43, 34));
        Assert.IsFalse(list.IsContain(43));
        Assert.Throws<OutOfListRangeException>(() => list.Change(0, -8));
        Assert.IsFalse(list.IsContain(0));
    }

    [Test]
    public void ChangeValueByCorrectPosition()
    {
        list.Change(-11, 0);
        Assert.IsTrue(list.IsContain(-11));
        list.Change(77, 1);
        Assert.IsTrue(list.IsContain(77));
    }

    [Test]
    public void RemoveValueByCorrectPositionAndDoesNotContainValue()
    {
        Assert.IsTrue(list.Remove(0) == -11);
        Assert.IsFalse(list.IsContain(-11));
        Assert.IsTrue(list.Remove(0) == 77);
        Assert.IsFalse(list.IsContain(77));
    }

    [Test]
    public void RemoveValueByIncorrectPosition()
    {
        Assert.Throws<OutOfListRangeException>(() => list.Remove(1234));
        Assert.Throws<OutOfListRangeException>(() => list.Remove(-3));
    }
}
