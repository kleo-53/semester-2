using System;
using bor;
class Program
{
    static void Main(string[] args)
    {
        Tree tree = new Tree();
        var continueProgram = true;
        while (continueProgram)
        {
            Console.WriteLine("Что вы хотите сделать с бором?\n0 - выйти из программы;\n1 - добавить слово в бор;\n2 - проверить, содержется ли " +
                "данное слово в боре;\n3 - удалить слово из бора;\n4 - узнать, сколько есть слов с заданным префиксом;" +
                "\n5 - узнать размер бора.");
            var inputString = Console.ReadLine();
            if (inputString == null)
            {
                Console.WriteLine("Введена пустая строка!");
                return;
            }
            switch (inputString)
            {
                case "1":
                    Console.WriteLine("Введите слово:");
                    var element = Console.ReadLine();
                    if (element == null)
                    {
                        Console.WriteLine("Введена пустая строка!");
                        return;
                    }
                    var result = tree.Add(element);
                    Console.WriteLine(result ? "В бор добавлено новое слово." : "В бор добавлено уже существующее там слово.");
                    break;
                case "2":
                    Console.WriteLine("Введите слово:");
                    element = Console.ReadLine();
                    if (element == null)
                    {
                        Console.WriteLine("Введена пустая строка!");
                        return;
                    }
                    result = tree.Contains(element);
                    Console.WriteLine(result ? "Бор содержит это слово." : "В боре нет этого слова.");
                    break;
                case "3":
                    Console.WriteLine("Введите слово:");
                    element = Console.ReadLine();
                    if (element == null)
                    {
                        Console.WriteLine("Введена пустая строка!");
                        return;
                    }
                    result = tree.Remove(element);
                    Console.WriteLine(result ? "Слово успешно удалено из бора." : "В боре не было этого слова.");
                    break;
                case "4":
                    Console.WriteLine("Введите слово:");
                    element = Console.ReadLine();
                    if (element == null)
                    {
                        Console.WriteLine("Введена пустая строка!");
                        return;
                    }
                    var count = tree.HowManyStartsWithPrefix(element);
                    Console.WriteLine("С этого префикса начинаются {0} слов.", count);
                    break;
                case "5":
                    Console.WriteLine("В боре сейчас {0} слов.", tree.Size);
                    break;
                case "0":
                    continueProgram = false;
                    break;
            }
        }
        return;
    }
}