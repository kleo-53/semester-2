using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    public class Operand : INode
    {
        public int operand;
        public INode ? leftSon { get; set; }
        public INode ? rightSon { get; set; }
        public Operand(int number) => this.operand = number;

        public int Calculate()
        {
            return operand;
        }

        public void PrintResult()
        {
            Console.Write(this.operand);
        }
    }
}
