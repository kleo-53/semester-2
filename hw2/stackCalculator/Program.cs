using System;
using StackCalculator;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Какой стек использовать?\n0 - на массиве\n1 - на списке");
        var stackType = Console.ReadLine();
        if (stackType != "1" && stackType != "0")
        {
            Console.WriteLine("Ожидался ответ 0 или 1!");
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
        catch (InvalidOperationException ex)
        { 
            Console.WriteLine(ex.Message); 
            return; 
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        return;
    }
}