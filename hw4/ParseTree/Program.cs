using System;


namespace ParseTree;
class Programm
{
    //FileStream fileStream = new FileStream("Test.txt", FileMode.Open, FileAccess.Read);
    public Main()
    {
        string[] data = File.ReadAllLines("Test.txt");
        if (data[0] == null)
        {
            return;
        }
        string equation = data[0];
        ParseTree tree = ParseTree.CreateAndAdd(equation);
        Console.WriteLine("All data in file: \n");
        tree.PrintTree(tree);
        int result = tree.DoCalculation(tree);
        Console.WriteLine($"\nAnd calculations result is: {result}");
        
    }
}