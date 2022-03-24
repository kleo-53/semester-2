using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    public class Operator : INode
    {
        public char operation;
        public INode leftSon;
        public INode rightSon;
        public Operator(char operation)
        {
        }

        public virtual int INode.Calculate()
        {
        }

        public void INode.PrintResult()
        {
            Console.WriteLine(this.operation);
        }
    }
}
