namespace SparseVector;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MySparseVector
{
    public List<(int, int)> NotNullPositions { get; set; }
    public int Size { get; set; }

    public MySparseVector()
    {
        NotNullPositions = new List<(int, int)>();
    }

    public MySparseVector(Dictionary<int, int> dictionary)
    {
        NotNullPositions = new List<(int, int)>();
        foreach (var element in dictionary)
        {
            NotNullPositions.Add((element.Key, element.Value));
            Size = Math.Max(Size, element.Key);
        }
    }

    public MySparseVector(int key, int value)
    {
        NotNullPositions = new List<(int, int)>();
        NotNullPositions.Add((key, value));
        Size = key;
    }
}
