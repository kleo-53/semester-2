namespace ParseTree;

/// <summary>
/// Класс элемента дерева
/// </summary>
public abstract class Operator : INode
{
    /// <summary>
    /// Левый сын элемента
    /// </summary>
    public INode ? leftSon { get; set; }

    /// <summary>
    /// Правый сын элемента
    /// </summary>
    public INode ? rightSon { get; set; }

    /// <summary>
    /// Выполняет вычисление
    /// </summary>
    /// <returns>Значение элемента</returns>
    public abstract int Calculate();

    /// <summary>
    /// Печатает результат вычисления на консоль
    /// </summary>
    public abstract void PrintResult();
}
