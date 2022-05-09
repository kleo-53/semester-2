namespace StackCalculator;

using System;

/// <summary>
/// Реализация структуры стека
/// </summary>
public interface IStack
{
    /// <summary>
    /// Добавляет элемент в стек
    /// </summary>
    /// <param name="element">Добавляемый элемент</param>
    void Push(double element);

    /// <summary>
    /// Удаляет и возвращает верхний элемент стека
    /// </summary>
    /// <returns>Удаленный элемент и true, либо false в случае пустого стека</returns>
    public (double, bool) Pop();

    /// <summary>
    /// Возвращает количество элементов в стеке
    /// </summary>
    /// <returns>Количество элементов</returns>
    int Count();

    /// <summary>
    /// Возвращает, пустой ли стек
    /// </summary>
    bool IsEmpty { get; }
}
