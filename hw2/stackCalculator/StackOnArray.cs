namespace StackCalculator;

using System;

/// <summary>
/// Реализация стека на массиве
/// </summary>
public class StackOnArray : IStack
{
    private double[] stack;
    private const int stackSize = 10;
    private int count;

    public StackOnArray()
    {
        stack = new double[stackSize];
    }

    public StackOnArray(int size)
    {
        stack = new double[size];
    }

    /// <summary>
    /// Добавляет элемент в стек
    /// </summary>
    /// <param name="element">Добавляемый элемент</param>
    public void Push(double element)
    {
        if (count == stack.Length)
        {
            Array.Resize(ref stack, stack.Length * 2);
        }
        ++count;
        stack[count] = element;
    }

    /// <summary>
    /// Возвращает, пустой ли стек
    /// </summary>
    public bool IsEmpty => count == 0;

    /// <summary>
    /// Возвращает количество элементов в стеке
    /// </summary>
    /// <returns>Количество элементов в стеке</returns>
    public int Count()
        => count;

    /// <summary>
    /// Удаляет и возвращает первый элемент стека, если стек не пуст
    /// </summary>
    /// <returns>Первый элемент стека</returns>
    public (double, bool) Pop()
    {
        if (IsEmpty)
        {
            return (0, false);
        }
        double element = stack[--count];
        if (count > 0 && count < stack.Length / 2)
        {
            Array.Resize(ref stack, stack.Length / 2);
        }
        return (element, true);
    }
}
