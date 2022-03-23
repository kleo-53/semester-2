using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    internal interface INode
    {
        public int Calculate();
        public void PrintResult();
    }
}
