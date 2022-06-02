namespace StackCalculator;

using System;

/// <summary>
/// Реализация стека на списке
/// </summary>
public class StackOnList : IStack
{
    private List<double> stack;

    /// <summary>
    /// Пустой конструктор
    /// </summary>
    public StackOnList()
    {
        stack = new List<double>();
    }

    /// <summary>
    /// Добавляет элемент в стек
    /// </summary>
    /// <param name="element">Добавляемый элемент</param>
    public void Push(double element)
    {
        stack.Insert(0, element);
    }

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
        if (IsEmpty)
        {
            return (0, false);
        }
        double element = stack.First();
        stack.RemoveAt(0);
        return (element, true);
    }
}