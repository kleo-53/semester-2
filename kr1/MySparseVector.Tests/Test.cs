namespace MySparseVector.Tests;

using NUnit.Framework;
using SparseVector;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void PlusTest()
    {
        var v1 = new SparseVector.MySparseVector(1, 2);
        var v2 = new SparseVector.MySparseVector(1, 3);
        var plus = new Plus();
        MySparseVector v3 = plus.Calculate(v1, v2);
        var v4 = new SparseVector.MySparseVector(1, 5);
        Assert.AreEqual(v3, v4);
    }

    [Test]
    public void MinusTest()
    {
        var v1 = new SparseVector.MySparseVector(1, 2);
        var v2 = new SparseVector.MySparseVector(1, 3);
        var plus = new Plus();
        MySparseVector v3 = plus.Calculate(v1, v2);
        var v4 = new SparseVector.MySparseVector(1, -1);
        Assert.AreEqual(v3, v4);
    }


    [Test]
    public void MultiplyTest()
    {
        var v1 = new SparseVector.MySparseVector(1, 2);
        var v2 = new SparseVector.MySparseVector(1, 3);
        var plus = new Plus();
        MySparseVector v3 = plus.Calculate(v1, v2);
        var v4 = new SparseVector.MySparseVector(1, 6);
        Assert.AreEqual(v3, v4);
    }


    [Test]
    public void DivisionTest()
    {
        var v1 = new SparseVector.MySparseVector(1, 2);
        var v2 = new SparseVector.MySparseVector(1, 3);
        var plus = new Plus();
        MySparseVector v3 = plus.Calculate(v1, v2);
        var v4 = new SparseVector.MySparseVector(1, 0);
        Assert.AreEqual(v3, v4);
    }
}
