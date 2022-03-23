using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    internal class Operator
    {
        public char operation;
        public INode leftSon;
        public INode rightSon;
        public Operator(char operation)
        {
            this.operation = operation;
            this.leftSon = null;
            this.rightSon = null;
        }

        public int Calculate()
        {
            switch (operation)
            {
                case '+':
                    return leftSon.Calculate() + rightSon.Calculate();

                case '-':
                    return leftSon.Calculate() - rightSon.Calculate();

                case '*':
                    return leftSon.Calculate() * rightSon.Calculate();

                case '/':
                    return leftSon.Calculate() / rightSon.Calculate();

                default:
                    {
                        Console.WriteLine("aboba");
                        return -2131412;
                    }
            }
        }
        public void PrintResult()
        {
            Console.WriteLine(Calculate());
        }
    }
}
