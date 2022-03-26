using NUnit.Framework;
using ParseTree;
using System;

namespace ParseTree.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EachCorrectOperationWorksCorrectlyWithNegativeTest()
        {
            var tree0 = new PTree();
            var tree = tree0.CreateAndAdd("+ 2 -4");
            Assert.IsTrue(tree.DoCalculation() == -2);
            var tree2 = tree0.CreateAndAdd("- -2 5");
            Assert.IsTrue(tree2.DoCalculation() == 7);
            var tree3 = tree0.CreateAndAdd("* 2 -9");
            Assert.IsTrue(tree3.DoCalculation() == -18);
            var tree4 = tree0.CreateAndAdd("/ -3 18");
            Assert.IsTrue(tree4.DoCalculation() == -6);
        }
        public void EachCorrectOperationWorksCorrectlyWithBigNumbersTest()
        {
            var tree0 = new PTree();
            var tree = tree0.CreateAndAdd("/ (+ 245325 745) 3245645");
            Assert.IsTrue(tree.DoCalculation() == 13);
            var tree2 = tree0.CreateAndAdd("- (* -5 (- -433332 -769760)) 45634634");
            Assert.IsTrue(tree2.DoCalculation() == 43952494);
            var tree3 = tree0.CreateAndAdd("/ (* 634246 54211) 23371538");
            Assert.IsTrue(tree3.DoCalculation() == 1);
            var tree4 = tree0.CreateAndAdd("- (+ (/ -46 111) 7453) 3421");
            Assert.IsTrue(tree4.DoCalculation() == -4030);
        }
        public void DividingByZeroTest()
        {
            var tree0 = new PTree();
            var tree = tree0.CreateAndAdd("/ 0 435");
            Assert.Throws<DivideByZeroException>(() => { tree.DoCalculation(); });
        }
        public void IncorrectInputDataTest()
        {
            var tree0 = new PTree();
            var tree = tree0.CreateAndAdd("= 0 435");
            Assert.Throws<InvalidOperationException>(() => { tree.DoCalculation(); });
            var tree2 = tree0.CreateAndAdd("= reyg u7u");
            Assert.Throws<InvalidOperationException>(() => { tree2.DoCalculation(); });
            var tree3 = tree0.CreateAndAdd("((()))");
            Assert.Throws<InvalidOperationException>(() => { tree3.DoCalculation(); });
            var tree4 = tree0.CreateAndAdd("45 + 5");
            Assert.Throws<InvalidOperationException>(() => { tree4.DoCalculation(); });
        }
    }
}