using System;
using StackCalculator.Tests;
using StackCalculator;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Какой стек использовать?\n0 - на массиве\n1 - на списке");
        var stackType = Console.ReadLine();
        if (stackType == null)
        {
            Console.WriteLine("Введен пустой массив!");
            return;
        }
        Console.WriteLine("Введите строку в обратной польской записи:");
        var inputString = Console.ReadLine();
        if (inputString == null)
        {
            Console.WriteLine("Введен пустой массив!");
            return;
        }
        try
        {
            var result = Calculator.Calculation(inputString, stackType);
            Console.WriteLine("Результат вычисления выражения: {0}", result);
        }
        catch (Exception ex)
        { 
            Console.WriteLine(ex.ToString()); 
            return; 
        }
        return;
    }
}