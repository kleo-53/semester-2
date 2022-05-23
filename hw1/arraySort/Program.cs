namespace ArraySort;

using System;

/// <summary>
/// Сортировка массива сортировкой пузырьком
/// </summary>
static class Program
{
    /// <summary>
    /// Меняет два элемента местами
    /// </summary>
    /// <param name="first">Первый элемент</param>
    /// <param name="second">Второй элемент</param>
    private static void Swap(ref int first, ref int second)
    {
        (first, second) = (second, first);
    }

    /// <summary>
    /// Сортирует массив сортировкой пузырьком
    /// </summary>
    /// <param name="sortingArray">Массив, который надо отсортировать</param>
    private static void BubbleSort(int[] sortingArray)
    {
        var length = sortingArray.Length;
        for (var i = 1; i < length; i++)
        {
            for (var j = 0; j < length - i; j++)
            {
                if (sortingArray[j] > sortingArray[j + 1])
                {
                    Swap(ref sortingArray[j], ref sortingArray[j + 1]);
                }
            }
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Введите элементы массива для сортировки пузырьком:");
        var inputString = Console.ReadLine();
        if (inputString == null)
        {
            Console.WriteLine("Введена некорректная строка!");
            return;
        }
        var arrayElements = inputString.Split(' ');
        var inputArray = new int[arrayElements.Length];
        for (var i = 0; i < arrayElements.Length; i++)
        {
            inputArray[i] = Convert.ToInt32(arrayElements[i]);
        }
        BubbleSort(inputArray);
        Console.WriteLine($"Отсортированный массив: {string.Join(' ', inputArray)}");
    }
}
