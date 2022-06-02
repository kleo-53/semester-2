namespace StackCalculator;

using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Какой стек использовать?\n0 - на массиве\n1 - на списке");
        var stackType = Console.ReadLine();
        if (stackType == null)
        {
            Console.WriteLine("Введена пустая строка!");
            return;
        }
        Console.WriteLine("Введите строку в обратной польской записи:");
        var inputString = Console.ReadLine();
        if (inputString == null)
        {
            Console.WriteLine("Введена пустая строка!");
            return;
        }
        var result = Calculator.Calculation(inputString, stackType == "0" ? new StackOnArray() : new StackOnList());
        Console.WriteLine(result.Item2 ? $"Результат вычисления выражения: {result.Item1}" : "Что-то пошло не так:(");
    }
}