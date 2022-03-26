using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    public class PTree
    {
        private INode ? root;
        public PTree()
        {
            this.root = null;
        }

        public int numberConvert(string givenString, ref int index)
        {
            int number = 0;
            while (index < givenString.Length && givenString[index] >= '0' && givenString[index] <= '9')
            {
                number = number* 10 + (int) (givenString[index] - '0');
                ++index;
            }
        return number;
        }

        public bool isOperation(char symbol, char next)
        {
            if (symbol == '+' || symbol == '*' || symbol == '/')
            {
                return true;
            }
            if (symbol == '-')
            {
                return '9' - next < 0 || next - '0' < 0;
            }
            return false;
        }

        private INode AddNodeRecursive(string givenString, ref int index)
        {
            ++index;
            while (index < givenString.Length && (givenString[index] == ' ' ||
                givenString[index] == '(' || givenString[index] == ')'))
            {
                ++index;
            }
            INode node;
            if (index == givenString.Length - 1)
            {
                if (givenString[index] - '0' >= 0 && '9' - givenString[index] > 0)
                {
                    node = new Operand(numberConvert(givenString, ref index));
                    return node;
                }
                throw new InvalidOperationException("incorrect string");
            }    
            if (isOperation(givenString[index], givenString[index + 1]))
            {
                switch (givenString[index])
                {
                    case '+':
                        {
                            node = new Plus();
                            break;
                        }
                    case '-':
                        {
                            node = new Minus();
                            break;
                        }
                    case '/':
                        {
                            node = new Divide();
                            break;
                        }
                    default:
                        {
                            node = new Multiply();
                            break;
                        }
                }
                node.leftSon = AddNodeRecursive(givenString, ref index);
                node.rightSon = AddNodeRecursive(givenString, ref index);
                return node;
            }
            else
            {
                if (givenString[index] == '-')
                {
                    ++index;
                    node = new Operand(numberConvert(givenString, ref index) * -1);
                }
                else
                {
                    node = new Operand(numberConvert(givenString, ref index));
                }

            }
            return node;
        }

        public PTree CreateAndAdd(string givenString)
        {
            PTree tree = new PTree();
            int index = -1;
            tree.root = AddNodeRecursive(givenString, ref index);
            return tree;
        }

        public int DoCalculation()
        {
            if (root == null)
            {
                throw new ArgumentNullException("empty root");
            }
            return root.Calculate();
        }

        private void PrintRecursive(INode node)
        {
            if (node.leftSon == null && node.rightSon == null)
            {
                node.PrintResult();
                return;
            }
            if (node.leftSon == null || node.rightSon == null)
            {
                throw new ArgumentNullException("empty node");
            }
            Console.Write("( ");
            node.PrintResult();
            Console.Write(" ");
            PrintRecursive(node.leftSon);
            Console.Write(" ");
            PrintRecursive(node.rightSon);
            Console.Write(" )");
        }

        public void PrintTree()
        {
            if (root == null)
            {
                throw new ArgumentNullException("enpty root");
            }
            PrintRecursive(root);
        }
    }
}
