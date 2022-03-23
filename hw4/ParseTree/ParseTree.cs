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
        public INode AddNodeRecursive(string givenString, ref int index)
        {
            ++index;
            while (index != givenString.Length && (givenString[index] == ' ' ||
                givenString[index] == '(' || givenString[index] == ')'))
            {
                ++index;
            }
            if (isOperation(givenString[index], givenString[index + 1]))
            {
                var node = new Operator(givenString[index]);
                node.leftSon = AddNodeRecursive(givenString, ref index);
                node.rightSon = AddNodeRecursive(givenString, ref index);
                return node;
            }
            if (givenString[index] == '-')
            {
                ++index;
                var node = new Operand(numberConvert(givenString, ref index) * -1);
                return node;
            }
            var node = new Operand(numberConvert(givenString, ref index));
            return node;
        }
    }
}
