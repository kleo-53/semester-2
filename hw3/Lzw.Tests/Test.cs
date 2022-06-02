namespace Lzw.Tests;

using NUnit.Framework;
using System.IO;

public class Tests
{
    [Test]
    public void StraightLzwTest()
    {
        Lzw.StraightLzw("TestText.txt");
        var correctFile = File.ReadAllText("CorrectTest.zipped");
        var afterLzwFile = File.ReadAllText("TestText.zipped");
        Assert.AreEqual(correctFile, afterLzwFile);
    }

    [Test]
    public void ReverseLzwTest()
    {
        Lzw.ReverseLzw("TestText.zipped");
        var correctFile = File.ReadAllText("CorrectTest.txt");
        var afterLzwFile = File.ReadAllText("TestText.txt");
        Assert.AreEqual(correctFile, afterLzwFile);
    }

    [Test]
    public void CoefficientTest()
    {
        var coefficient = Lzw.StraightLzw("TestText.txt");
        Assert.IsTrue(coefficient > 1);
        coefficient = Lzw.ReverseLzw("TestText.zipped");
        Assert.IsTrue(coefficient > 1);
    }
}
