namespace SparseVector;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Multiply : Operation
{
    public MySparseVector Calculate(MySparseVector firstVector, MySparseVector secondVector)
    {
        return base.Calculate(firstVector, secondVector, '*');
    }
}
