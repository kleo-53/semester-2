using System;

namespace StackCalculator;

public class StackOnList : IStack
{

    private List<double> stack;
    private const int stackSize = 10;
    private int count;
    public StackOnList()
    {
        stack = new List<double>();
    }
    // Добавляет элемент
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
        double element = stack.First();
        stack.RemoveAt(0);
        --count;
        return element;
    }
}