using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    public class Minus : Operator
    {
        public override int Calculate()
        {
            if (this.leftSon == null || this.rightSon == null)
            {
                throw new ArgumentNullException("empty node");
            }
            return this.rightSon.Calculate() - this.leftSon.Calculate();
        }
        public override void PrintResult()
        {
            Console.Write("-");
        }
    }
}
