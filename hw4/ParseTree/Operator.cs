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
            switch (operation)
            {
                case '+':
                    {
                        Plus();
                        break;
                    }
                case '-':
                    {
                        Minus();
                        break;
                    }
                case '*':
                    {
                        Multiply();
                        break;
                    }
                case '/':
                    {
                        Divide();
                        break;
                    }
            }
        }

        public virtual int INode.Calculate()
        {
        }

        public virtual void INode.PrintResult()
        {
        }
    }
}
