namespace ParseTree;

using System;

/// <summary>
/// Класс дерева
/// </summary>
public class PTree
{
    private INode ? root;

    /// <summary>
    /// Конструктор дерева
    /// </summary>
    public PTree()
    {
        this.root = null;
    }

    /// <summary>
    /// Преобразование строки в число
    /// </summary>
    /// <param name="givenString">Данная строка</param>
    /// <param name="index">Индекс текущего элемента</param>
    /// <returns>Число, полученное из строки</returns>
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

    /// <summary>
    /// Проверка символа на арифметическую операцию
    /// </summary>
    /// <param name="symbol">Данный символ</param>
    /// <param name="next">Следующий символ</param>
    /// <returns>Является ли текущий символ арифметической операцией</returns>
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

    /// <summary>
    /// Создание дерева по строке
    /// </summary>
    /// <param name="givenString">Данная строка</param>
    /// <returns>Построенное дерево</returns>
    public PTree CreateAndAdd(string givenString)
    {
        PTree tree = new PTree();
        int index = -1;
        tree.root = AddNodeRecursive(givenString, ref index);
        return tree;
    }

    /// <summary>
    /// Выполнение вычисления по дереву
    /// </summary>
    /// <returns>Результат вычисления</returns>
    /// <exception cref="ArgumentNullException">Ошибка в случае пустого дерева</exception>
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

    /// <summary>
    /// Распечатывает дерево в файл
    /// </summary>
    /// <exception cref="ArgumentNullException">Ошибка в случае пустого дерева</exception>
    public void PrintTree()
    {
        if (root == null)
        {
            throw new ArgumentNullException("enpty root");
        }
        PrintRecursive(root);
    }
}
