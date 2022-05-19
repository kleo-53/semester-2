namespace Test.Tests;

using NUnit.Framework;
using System.Collections.Generic;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void IntListTest()
    {
        var testList = new List<int>();
        testList.Add(1);
        testList.Add(4);
        testList.Add(-8);
        testList.Add(2); 
        IntComparer intComparer = new IntComparer();
        var afterComparation = BubbleSort<int>.Sort(testList, intComparer);
        var correctList = new List<int>();
        correctList.Add(-8);
        correctList.Add(1);
        correctList.Add(2);
        correctList.Add(4);
        Assert.AreEqual(correctList, afterComparation);
    }

    [Test]
    public void StringListTest()
    {
        var testList = new List<string>();
        testList.Add("qwer");
        testList.Add("aaaaa");
        testList.Add("qr439tfherui");
        testList.Add("123");
        StringComparer stringComparer = new StringComparer();
        var afterComparation = BubbleSort<string>.Sort(testList, stringComparer);
        var correctList = new List<string>();
        correctList.Add("123");
        correctList.Add("aaaaa");
        correctList.Add("qr439tfherui");
        correctList.Add("qwer");
        Assert.AreEqual(correctList, afterComparation);
    }

    [Test]
    public void IntAndStringPairListTest()
    {
        var testList = new List<(int, string)>();
        testList.Add((43827834, "qwer"));
        testList.Add((18, "qwer"));
        testList.Add((43827834, "aaaaa"));
        testList.Add((0, "qr439tfherui"));
        testList.Add((0, "123"));
        StringAndIntComparer stringAndIntComparer = new StringAndIntComparer();
        var afterComparation = BubbleSort<(int, string)>.Sort(testList, stringAndIntComparer);
        var correctList = new List<(int, string)>();
        correctList.Add((0, "123"));
        correctList.Add((0, "qr439tfherui"));
        correctList.Add((18, "qwer"));
        correctList.Add((43827834, "aaaaa"));
        correctList.Add((43827834, "qwer"));
        Assert.AreEqual(correctList, afterComparation);
    }
}
