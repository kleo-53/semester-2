namespace ParseTree;

using System;

/// <summary>
/// Класс дерева
/// </summary>
public class PTree
{
    private INode ? root;

    /// <summary>
    /// Преобразование строки в число
    /// </summary>
    /// <param name="givenString">Данная строка</param>
    /// <param name="index">Индекс текущего элемента</param>
    /// <returns>Число, полученное из строки</returns>
    public int NumberConvert(string givenString, ref int index)
    {
        int number = 0;
        while (index < givenString.Length && givenString[index] >= '0' && givenString[index] <= '9')
        {
            number = number * 10 + (int)(givenString[index] - '0');
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
    public bool IsOperation(char symbol, char next)
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
        if (index == givenString.Length - 1)
        {
            if (givenString[index] - '0' >= 0 && '9' - givenString[index] > 0)
            {
                return new Operand(NumberConvert(givenString, ref index));
            }
            throw new InvalidOperationException("incorrect string");
        }
        else if (index > givenString.Length - 1)
        {
            return null;
        }
        if (IsOperation(givenString[index], givenString[index + 1]))
        {
            var node = new Operator(givenString[index]);
            node.LeftSon = AddNodeRecursive(givenString, ref index);
            node.RightSon = AddNodeRecursive(givenString, ref index);
            return node;
        }
        else
        {
            if (givenString[index] == '-')
            {
                ++index;
                return new Operand(NumberConvert(givenString, ref index) * -1);
            }
            return new Operand(NumberConvert(givenString, ref index));
        }
    }

    /// <summary>
    /// Создание дерева по строке
    /// </summary>
    /// <param name="givenString">Данная строка</param>
    /// <returns>Построенное дерево</returns>
    public PTree CreateAndAdd(string givenString)
    {
        var tree = new PTree();
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
        node.PrintResult();
    }

    /// <summary>
    /// Распечатывает дерево на консоль
    /// </summary>
    /// <exception cref="ArgumentNullException">Ошибка в случае пустого дерева</exception>
    public void PrintTree()
    {
        if (root == null)
        {
            throw new InvalidOperationException("enpty root");
        }
        PrintRecursive(root);
    }
}
