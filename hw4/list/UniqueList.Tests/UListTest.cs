namespace UniqueList.Tests;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using global::UniqueList;

public class UListTest
{ 
    private static IEnumerable<global::UniqueList.List> ListToTest
    {
        get
        {
            yield return new global::UniqueList.List();
            yield return new UniqueList();
        }
    }

    [TestCaseSource(nameof(ListToTest))]
    public void AddValueByCorrectPositionAndContainValueTest(global::UniqueList.List list)
    {
        list.Add(1421);
        Assert.IsTrue(list.Contains(1421));
        list.Add(-235, 1);
        list.Add(-4, 1);
        list.Add(346);
        Assert.IsTrue(list.Contains(-235));
        Assert.IsFalse(list.Contains(0));
    }

    [TestCaseSource(nameof(ListToTest))]
    public void AddValueByIncorrectPositionAndDoesNotContainValue(global::UniqueList.List list)
    {
        Assert.Throws<IndexOutOfRangeException>(() => list.Add(34, 100));
        Assert.IsFalse(list.Contains(34));
        Assert.Throws<IndexOutOfRangeException>(() => list.Add(45, -65));
        Assert.IsFalse(list.Contains(45));
    }

    [TestCaseSource(nameof(ListToTest))]
    public void ChangeValueByIncorrectPosition(global::UniqueList.List list)
    {
        list.Add(1421);
        Assert.Throws<IndexOutOfRangeException>(() => list.Change(43, 34));
        Assert.IsFalse(list.Contains(43));
        Assert.Throws<IndexOutOfRangeException>(() => list.Change(0, -8));
        Assert.IsFalse(list.Contains(0));
    }

    [TestCaseSource(nameof(ListToTest))]
    public void ChangeValueByCorrectPosition(global::UniqueList.List list)
    {
        list.Add(1421);
        list.Add(-235, 1);
        list.Add(-4, 1);
        list.Add(346);
        list.Change(-11, 0);
        Assert.IsTrue(list.Contains(-11));
        list.Change(77, 1);
        Assert.IsTrue(list.Contains(77));
    }

    [TestCaseSource(nameof(ListToTest))]
    public void RemoveValueByCorrectPositionAndDoesNotContainValue(global::UniqueList.List list)
    {
        list.Add(1421);
        list.Add(-235, 1);
        list.Add(-4, 1);
        list.Add(346);
        list.Change(-11, 0);
        list.Change(77, 1);
        Assert.AreEqual(list.Remove(0), -11);
        Assert.IsFalse(list.Contains(-11));
        Assert.AreEqual(list.Remove(0), 77);
        Assert.IsFalse(list.Contains(77));
    }

    [TestCaseSource(nameof(ListToTest))]
    public void RemoveValueByIncorrectPosition(global::UniqueList.List list)
    {
        list.Add(1421);
        list.Add(-235, 1);
        Assert.Throws<IndexOutOfRangeException>(() => list.Remove(1234));
        Assert.Throws<IndexOutOfRangeException>(() => list.Remove(-3));
    }
}
