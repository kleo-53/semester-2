namespace Test.Tests;

using System.Collections.Generic;

/// <summary>
/// Компаратор для списка, каждый элемент которого состоит числа и строки
/// </summary>
public class StringAndIntComparer : Comparer<(int, string)>
{
    public override int Compare((int, string) x, (int, string) y)
    {
        if (x.Item1.CompareTo(y.Item1) < 0 || x.Item1.CompareTo(y.Item1) > 0)
        {
            return x.Item1.CompareTo(y.Item1);
        }
        else
        {
            return x.Item2.CompareTo(y.Item2);
        }
    }
}
