namespace ParseTree;

using System;

/// <summary>
/// Класс операции сложения
/// </summary>
public class Plus : Operator
{
    /// <summary>
    /// Калькулятор выполняет деление
    /// </summary>
    /// <returns>Полученное значение</returns>
    public override int Calculate()
    {
        if (this.leftSon == null || this.rightSon == null)
        {
            throw new ArgumentNullException("empty node");
        }
        return this.rightSon.Calculate() + this.leftSon.Calculate();
    }

    /// <summary>
    /// Вывод действия на консоль
    /// </summary>
    public override void PrintResult()
    {
        Console.Write("+");
    }
}
