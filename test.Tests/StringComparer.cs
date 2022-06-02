namespace Test.Tests;

using System.Collections.Generic;

/// <summary>
/// Компаратор для строк
/// </summary>
internal class StringComparer : Comparer<string>
{
    public override int Compare(string? x, string? y)
    {
        return x.CompareTo(y);
    }
}
