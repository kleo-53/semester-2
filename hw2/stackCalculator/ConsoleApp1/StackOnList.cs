using System;

namespace StackCalculator.Tests;

internal class StackOnList : IStack
{

    private List<double> stack;
    private const int stackSize = 10;
    private int count;
    public StackOnList()
    {
        stack = new List<double>();
    }
    public StackOnList(int size)
    {
        stack = new double[size];
    }
    // Добавляет элемент
    public void Push(double element)
    {
        if (count == stack.Length)
        {
            Array.Resize(ref stack, stack.Length + 10);
        }
        stack[count++] = element;
    }
    // Возвращает, пустой ли стек
    public bool IsEmpty
    {
        get { return count == 0; }
    }
    // Возвращает размер стека
    public int Count()
    {
        return count;
    }
    // Удаляет и возвращает первый элемент стека
    public double Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Стек пуст");
        }
        double element = stack[--count];
        stack[count] = default(double);
        if (count > 0 && count < stack.Length - 10)
        {
            Array.Resize(ref stack, stack.Length - 10);
        }
        return element;
    }
}