namespace StackCalculator;

using System;

namespace StackCalculator
/// <summary>
/// Реализация стека на массиве
/// </summary>
public class StackOnArray : IStack
{
    public class StackOnArray : IStack



    private double[] stack;
    private const int stackSize = 10;
    private int count;

    /// <summary>
    /// Пустой конструктор
    /// </summary>
    public StackOnArray()
    {
        private double[] stack;
        private const int stackSize = 10;
        private int count;
        public StackOnArray()
        stack = new double[stackSize];
    }

    /// <summary>
    /// Конструктор по размеру стека
    /// </summary>
    /// <param name="size">Данный размер</param>
    public StackOnArray(int size)
    {
        if (size <= 0)





        {
            stack = new double[stackSize];
            throw new ArgumentException("");
        }
        public StackOnArray(int size)
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
            stack = new double[size];
            Array.Resize(ref stack, stack.Length * 2);
        }
        // Добавляет элемент
        public void Push(double element)
        stack[count] = element;
        ++count;
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
            if (count == stack.Length)
            {
                Array.Resize(ref stack, stack.Length + 10);
            }
            stack[count++] = element;
            return (0, false);
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
        --count;
        double element = stack[count];
        if (count > 0 && count < stack.Length / 2)
        {
            Array.Resize(ref stack, stack.Length / 2);
        }
        return (element, true);
    }
}
