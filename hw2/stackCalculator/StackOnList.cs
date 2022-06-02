namespace StackCalculator;

using System;

namespace StackCalculator;

/// <summary>
/// Реализация стека на списке
/// </summary>
public class StackOnList : IStack
{
    private List<double> stack;

    private List<double> stack;
    private const int stackSize = 10;
    private int count;
    /// <summary>
    /// Пустой конструктор
    /// </summary>
    public StackOnList()
    {
        stack = new List<double>();
    }
    // Добавляет элемент

    /// <summary>
    /// Добавляет элемент в стек
    /// </summary>
    /// <param name="element">Добавляемый элемент</param>
    public void Push(double element)
    {
        stack.Insert(0, element);
        ++count;
    }
    // Возвращает, пустой ли стек
    public bool IsEmpty
    {
        get { return count == 0; }
    }
    // Возвращает размер стека

    /// <summary>
    /// Возвращает, пустой ли стек
    /// </summary>
    public bool IsEmpty => stack.Count == 0;

    /// <summary>
    /// Возвращает количество элементов в стеке
    /// </summary>
    /// <returns>Количество элементов</returns>
    public int Count()
        => stack.Count;

    /// <summary>
    /// Удаляет и возвращает верхний элемент стека
    /// </summary>
    /// <returns>Удаленный элемент и true, либо false в случае пустого стека</returns>
    public (double, bool) Pop()
    {
        return count;
    }
    // Удаляет и возвращает первый элемент стека
    public double Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Стек пуст");
            return (0, false);
        }
        double element = stack.First();
        stack.RemoveAt(0);
        --count;
        return element;
        return (element, true);
    }
}