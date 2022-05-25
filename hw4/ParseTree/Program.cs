namespace ParseTree;

using System;

/// <summary>
/// Тест программы
/// </summary>
class Programm
{
    //FileStream fileStream = new FileStream("Test.txt", FileMode.Open, FileAccess.Read);
    public static void Main(string[] args)
    {
        string[] data = File.ReadAllLines("C:/Users/Star/source/repos/semester-2/hw4/ParseTree/Test.txt");
        if (data[0] == null)
        {
            return;
        }
        string equation = data[0];
        var tree0 = new PTree();
        var tree = tree0.CreateAndAdd(equation);
        Console.WriteLine("All data in file:");
        tree.PrintTree();
        try
        {
            int result = tree.DoCalculation();
            Console.Write($"\nAnd result of calculations is: {result}");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("\nTree was empty!");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("\nIncorrect string format!");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("\nCan not divide by zero!");
        }
    }
}