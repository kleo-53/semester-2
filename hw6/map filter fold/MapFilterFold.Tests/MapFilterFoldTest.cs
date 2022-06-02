using NUnit.Framework;
using MapFilterFold;
using System.Collections.Generic;

namespace MapFilterFold.Tests;

public class Test
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void MapTest() => Assert.AreEqual(MapFilterFoldFunctions.Map(new List<int>
    { 1, -2, 3, 0 }, x => x * 4), new List<int> { 4, -8, 12, 0 });

    [Test]
    public void FilterTest() => Assert.AreEqual(MapFilterFoldFunctions.Filter(new List<int>
    { 1, -2, 3, 0 }, x => x % 3 == 1), new List<int> { 1 });

    [Test]
    public void FoldTest() => Assert.AreEqual(MapFilterFoldFunctions.Fold(new List<int>
    { 1, -2, 3, 0 }, -8, (x, y) => x + 2 * y), -4);
}
