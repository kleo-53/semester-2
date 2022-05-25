namespace ParseTree;

using System;

/// <summary>
/// Класс элемента дерева
/// </summary>
public class Operand : INode
{
    /// <summary>
    /// Значение элемента 
    /// </summary>
    public int operand;

    /// <summary>
    /// Левый сын элемента
    /// </summary>
    public INode ? leftSon { get; set; }

    /// <summary>
    /// Правый сын элемента
    /// </summary>
    public INode ? rightSon { get; set; }

    /// <summary>
    /// Конструктор элемента
    /// </summary>
    /// <param name="number">Данное число</param>
    public Operand(int number) => this.operand = number;

    /// <summary>
    /// Выполняет вычисление
    /// </summary>
    /// <returns>Значение элемента</returns>
    public int Calculate()
    {
        return operand;
    }

    /// <summary>
    /// Печатает результат вычисления на консоль
    /// </summary>
    public void PrintResult()
    {
        Console.Write(this.operand);
    }
}
