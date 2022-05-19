namespace Test.Tests;

using System.Collections.Generic;

/// <summary>
/// Компаратор для чисел
/// </summary>
public class IntComparer : Comparer<int>
{
    public override int Compare(int x, int y)
    {
        return x.CompareTo(y);
    }
}
