namespace SparseVector;

using System;

public class Program
{
    public static void Main(string[] args)
    {
        var v1 = new SparseVector.MySparseVector(1, 2);
        var v2 = new SparseVector.MySparseVector(1, 3);
        var plus = new Plus();
        MySparseVector v3 = plus.Calculate(v1, v2);
    }
}