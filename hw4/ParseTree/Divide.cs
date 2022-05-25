namespace ParseTree;

using System;

/// <summary>
/// Класс операции деления
/// </summary>
public class Divide : Operator
{
    /// <summary>
    /// Калькулятор выполняет деление
    /// </summary>
    /// <returns>Полученное значение</returns>
    /// <exception cref="DivideByZeroException">Ошибка в случае деления на 0</exception>
    public override int Calculate()
    {
        if (this.rightSon == null || this.leftSon == null)
        {
            throw new ArgumentNullException("empty node");
        }
        try
        {
            return this.rightSon.Calculate() / this.leftSon.Calculate();
        }
        catch (DivideByZeroException)
        {
            throw new DivideByZeroException();
        }
    }

    /// <summary>
    /// Вывод действия на консоль
    /// </summary>
    public override void PrintResult()
    {
        Console.Write("/");
    }
}
