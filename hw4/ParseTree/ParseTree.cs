using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    internal class ParseTree
    {
        private INode root;
        public ParseTree()
        {
            this.root = null;
        }

        public bool IsEmpty(ParseTree tree)
        {
            return (tree.root == null);
        }

        public int numberConvert(string givenString, ref int index)
        {
            int number = 0;
            while (givenString[index] >= '0' && givenString[index] <= '9')
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
            while (index != givenString.Length && (givenString[index] == ' ' ||
                givenString[index] == '(' || givenString[index] == ')'))
            {
                ++index;
            }
            INode node;
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
                    case '*':
                        {
                            node = new Multiply();
                            break;
                        }
                    case '/':
                        {
                            node = new Divide();
                            break;
                        }
                }
                node.leftSon = AddNodeRecursive(givenString, ref index);
                node.rightSon = AddNodeRecursive(givenString, ref index);
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

        public ParseTree CreateAndAdd(string givenString)
        {
            ParseTree tree = new ParseTree();
            int index = -1;
            tree.root = AddNodeRecursive(givenString, ref index);
            return tree;
        }

        private int CalculateRecursive(INode node)
        {
            if (node.leftSon == null && node.rightSon == null)
            {
                return node.Calculate();
            }
            const int operandFirst = CalculateRecursive(node.leftSon);
            const int operandSecond = CalculateRecursive(node.rightSon);
            switch (node.operation)
            {
                case '+':
                    return operandFirst + operandSecond;
                case '-':
                    return operandFirst - operandSecond;
                case '/':
                    {
                        if (operandSecond == 0)
                        {
                            return -1;
                        }
                        return operandFirst / operandSecond;
                    }
                default:
                    return operandFirst * operandSecond;
            }
        }

        public int DoCalculation(ParseTree tree)
        {
            return CalculateRecursive(tree.root);
        }

        private void PrintRecursive(INode node)
        {
            if (node.leftSon == null && node.rightSon == null)
            {
                node.PrintResult();
                return;
            }
            node.PrintResult();
            PrintRecursive(node.leftSon);
            Console.Write(" ");
            PrintRecursive(node.rightSon);
            Console.Write(" )");
        }

        public void PrintTree(ParseTree tree)
        {
            if (tree.IsEmpty())
            {
                return;
            }
            PrintRecursive(tree.root);
        }
    }
}
