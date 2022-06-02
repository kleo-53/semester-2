using NUnit.Framework;
using System;
using UniqueList;

namespace UniqueList.Tests;

public class UUniqueListTest
{
    private UniqueList uList;

    [SetUp]
    public void Setup()
    {
        uList = new UniqueList();
    }

    [Test]
    public void AddValueByCorrectPositionAndContainValueTest()
    {
        uList.Add(14);
        Assert.IsTrue(uList.Contains(14));
        uList.Add(-235, 1);
        Assert.IsTrue(uList.Contains(-235));
        Assert.IsFalse(uList.Contains(0));
    }

    [Test]
    public void AddSameValueByCorrectPosition()
    {
        uList.Add(1421);
        Assert.Throws<AddRepeatedElementException>(() => uList.Add(1421));
        Assert.IsTrue(uList.Contains(1421));
        Assert.Throws<AddRepeatedElementException>(() => uList.Add(1421, 0));
    }

    [Test]
    public void AddValueByIncorrectPositionAndDoesNotContainValue()
    {
        Assert.Throws<IndexOutOfRangeException>(() => uList.Add(34, 100));
        Assert.IsFalse(uList.Contains(34));
        Assert.Throws<IndexOutOfRangeException>(() => uList.Add(45, -65));
        Assert.IsFalse(uList.Contains(45));
    }
}
