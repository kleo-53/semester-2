namespace MapFilterFold.Tests;

using NUnit.Framework;
using MapFilterFold;
using System.Collections.Generic;

public class Test
{
    [Test]
    public void MapTestMultiply() => Assert.AreEqual(MapFilterFoldFunctions.Map(new List<int>
        { 1, -2, 3, 0 }, x => x * 4), new List<int> { 4, -8, 12, 0 });

    [Test]
    public void MapTestSquare() => Assert.AreEqual(MapFilterFoldFunctions.Map(new List<int>
        { 1, 2, 3, 4 }, x => x * x), new List<int>() { 1, 4, 9, 16 });

    [Test]
    public void MapEmptySquare() => Assert.AreEqual(MapFilterFoldFunctions.Map(new List<int>
        { }, x => x * 2432), new List<int>() { });

    [Test]
    public void FilterTestDivision() => Assert.AreEqual(MapFilterFoldFunctions.Filter(new List<int>
        { 1, -2, 3, 0 }, x => x % 3 == 1), new List<int> { 1 });

    [Test]
    public void FilterInequalityTest() => Assert.AreEqual(MapFilterFoldFunctions.Filter(new List<int>
        { 1, 2, 3, 4, 5, 10}, x => x < 3), new List<int>() { 1, 2 });

    [Test]
    public void FilterEmptyTest() => Assert.AreEqual(MapFilterFoldFunctions.Filter(new List<int>
        { }, x => x > 0), new List<int>() { });

    [Test]
    public void FoldMultiplyTest() => Assert.AreEqual(MapFilterFoldFunctions.Fold(new List<int>
        { 1, -2, 3, 0 }, -8, (x, y) => x + 2 * y), -4);

    [Test]
    public void FoldSubtractionTest() => Assert.AreEqual(MapFilterFoldFunctions.Fold(new List<int>
        { 1, 2, 3, 4 }, 1, (x, y) => x - y), -9);

    [Test]
    public void FoldEmptyTest() => Assert.AreEqual(MapFilterFoldFunctions.Fold(new List<int>
        { }, 1, (x, y) => x * y), 1);
}