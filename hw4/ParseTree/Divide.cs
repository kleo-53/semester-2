using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    public class Divide : Operator
    {
        public override int Calculate()
        {
            if (this.rightSon == null || this.leftSon == null)
            {
                throw new ArgumentNullException("empty node");
            }
            try
            {
                return this.rightSon.Calculate() / this.leftSon.Calculate();
            }
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException();
            }
        }
        public override void PrintResult()
        {
            Console.Write("/");
        }
    }
}
