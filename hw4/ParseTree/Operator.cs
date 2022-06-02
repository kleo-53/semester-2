namespace ParseTree;

/// <summary>
/// Класс элемента дерева
/// </summary>
public class Operator : INode
{
    /// <summary>
    /// Левый сын элемента
    /// </summary>
    public INode ? LeftSon { get; set; }

    /// <summary>
    /// Правый сын элемента
    /// </summary>
    public INode ? RightSon { get; set; }

    private char symbol;

    /// <summary>
    /// Конструктор оператора
    /// </summary>
    public Operator(char symbol)
    {
        this.symbol = symbol;
    }

    /// <summary>
    /// Выполняет вычисление
    /// </summary>
    /// <returns>Значение элемента</returns>
    public int Calculate()
    {
        if (this.LeftSon == null || this.RightSon == null)
        {
            throw new InvalidOperationException("empty node");
        }
        switch (symbol)
        {
            case '+':
                return this.RightSon.Calculate() + this.LeftSon.Calculate();
            case '-':
                return this.RightSon.Calculate() - this.LeftSon.Calculate();
            case '*':
                return this.RightSon.Calculate() * this.LeftSon.Calculate();
            case '/':
                if (LeftSon.Calculate() != 0)
                {
                    return RightSon.Calculate() / LeftSon.Calculate();
                }
                else
                {
                    throw new DivideByZeroException();
                }
            default:
                throw new InvalidDataException();
        }
    }

    /// <summary>
    /// Печатает результат вычисления на консоль
    /// </summary>
    public void PrintResult()
    {
        if (LeftSon == null && RightSon == null)
        {
            Console.Write(symbol.ToString());
        }
        if (LeftSon == null || RightSon == null)
        {
            throw new ArgumentNullException("empty node");
        }
        Console.Write("( ", symbol.ToString(), " ");
        LeftSon.PrintResult();
        Console.Write(" ");
        RightSon.PrintResult();
        Console.Write(" )");
    }
}
