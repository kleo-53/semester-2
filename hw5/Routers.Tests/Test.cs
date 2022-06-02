namespace Routers.Tests;

using NUnit.Framework;
using System.IO;

public class Tests
{
    [Test]
    public void UnconnectedGraphTest()
    {
        Assert.IsFalse(RoutersUtility.Utility("TestUnIn.txt", "TestUnOut.txt"));
    }

    [Test]
    public void ConnectedGraphTest()
    {
        Assert.IsTrue(RoutersUtility.Utility("TestConIn.txt", "TestConOut.txt"));
        var afterUtility = File.ReadAllText("TestConOut.txt");
        var correctResult = File.ReadAllText("TestConCorrect.txt");
        Assert.AreEqual(afterUtility, correctResult);
    }
}
