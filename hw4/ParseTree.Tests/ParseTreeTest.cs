namespace ParseTree.Tests;

using NUnit.Framework;
using ParseTree;
using System;

public class Tests
{
    [Test]
    public void EachCorrectOperationWorksCorrectlyWithNegativeTest()
    {
        var tree0 = new PTree();
        var tree = tree0.CreateAndAdd("+ 2 -4"); 
        Assert.AreEqual(-2, tree.DoCalculation());
        var tree2 = tree0.CreateAndAdd("- -2 5"); 
        Assert.AreEqual(7, tree2.DoCalculation());
        var tree3 = tree0.CreateAndAdd("* 2 -9"); 
        Assert.AreEqual(-18, tree3.DoCalculation());
        var tree4 = tree0.CreateAndAdd("/ -3 18"); 
        Assert.AreEqual(-6, tree4.DoCalculation());
    }

    [Test]
    public void EachCorrectOperationWorksCorrectlyWithBigNumbersTest()
    {
        var tree0 = new PTree();
        var tree = tree0.CreateAndAdd("/ (+ 245325 745) 3245645");
        Assert.AreEqual(tree.DoCalculation(), 13);
        var tree2 = tree0.CreateAndAdd("- (* -5 (- -433332 -769760)) 45634634");
        Assert.AreEqual(tree2.DoCalculation(), 43952494);
        var tree3 = tree0.CreateAndAdd("/ (* 634246 54211) 23371538");
        Assert.AreEqual(tree3.DoCalculation(), 1);
        var tree4 = tree0.CreateAndAdd("- (+ (/ -46 111) 7453) 3421");
        Assert.AreEqual(tree4.DoCalculation(), -4030);
    }

    [Test]
    public void DividingByZeroTest()
    {
        var tree0 = new PTree();
        var tree = tree0.CreateAndAdd("/ 0 435"); 
        Assert.Throws<DivideByZeroException>(() => tree.DoCalculation());
    }

    [Test]
    public void IncorrectInputDataTest()
    {
        var tree0 = new PTree();
        var tree = tree0.CreateAndAdd("* 0 * 435 * 4");
        Assert.Throws<InvalidOperationException>(() => { tree.DoCalculation(); });
        var tree3 = tree0.CreateAndAdd("((()))");
        Assert.Throws<ArgumentNullException>(() => { tree3.DoCalculation(); });
        var tree4 = tree0.CreateAndAdd("/ 45 +4t3 5");
        Assert.AreEqual(tree4.DoCalculation(), 0);
    }
}
