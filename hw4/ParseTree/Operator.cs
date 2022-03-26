using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    public abstract class Operator : INode
    {
        public INode ? leftSon { get; set; }
        public INode ? rightSon { get; set; }

        public abstract int Calculate();

        public abstract void PrintResult();
    }
}
