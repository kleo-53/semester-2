using NUnit.Framework;
using System;
using UniqueList;

namespace UniqueList.Tests;

public class UUniqueListTest
{
    private UUniqueList uList = new UUniqueList();

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddValueByCorrectPositionAndContainValueTest()
    {
        uList.Add(14);
        Assert.IsTrue(uList.IsContain(14));
        uList.Add(-235, 1);
        Assert.IsTrue(uList.IsContain(-235));
        Assert.IsFalse(uList.IsContain(0));
    }

    [Test]
    public void AddSameValueByCorrectPosition()
    {
        uList.Add(1421);
        Assert.Throws<AddRepeatedElementException>(() => uList.Add(1421));
        Assert.IsTrue(uList.IsContain(1421));
        Assert.Throws<AddRepeatedElementException>(() => uList.Add(1421, 0));
    }

    [Test]
    public void AddValueByIncorrectPositionAndDoesNotContainValue()
    {
        Assert.Throws<OutOfListRangeException>(() => uList.Add(34, 100));
        Assert.IsFalse(uList.IsContain(34));
        Assert.Throws<OutOfListRangeException>(() => uList.Add(45, -65));
        Assert.IsFalse(uList.IsContain(45));
    }
}
