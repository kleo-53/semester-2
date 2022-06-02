namespace BWT;

using System;

/// <summary>
/// Класс выполняет преобразование Барроуза-Уиллера
/// </summary>
public class Bwt
{
    private const int arraySize = Char.MaxValue;

    private static void Swap(ref string first, ref string second)
    {
        var temporary = first;
        first = second;
        second = temporary;
    }

    private static void SuffixesSort(string[] suffixes)
    {
        for (int i = 1; i < suffixes.Length; i++)
        {
            var j = i;
            while (j > 0 && string.Compare(suffixes[j], suffixes[j - 1]) < 0)
            {
                Swap(ref suffixes[j - 1], ref suffixes[j]);
                j--;
            }
        }
    }

    /// <summary>
    /// Прямое преобразование БВТ
    /// </summary>
    /// <param name="givenString">Строка, над которой нужно совершить преобразование</param>
    /// <returns></returns>
    public static (string, int) StraightBwt(string givenString)
    {
        var indexToInverseBwt = -1;
        givenString += '\0';
        var suffixes = new string[givenString.Length];
        for (int i = 0; i < givenString.Length; i++)
        {
            suffixes[i] = givenString.Substring(i);
        }
        SuffixesSort(suffixes);
        string resultString = "";
        for (int i = 0; i < suffixes.Length; i++)
        {
            if (givenString.Length - suffixes[i].Length > 0)
            {
                resultString += givenString[givenString.Length - suffixes[i].Length - 1];
            }
            else
            {
                resultString += givenString[givenString.Length - 1];
            }

            if (suffixes[i].Length == givenString.Length)
            {
                indexToInverseBwt = i;
            }
        }
        return (resultString, indexToInverseBwt);
    }

    private static string SortingString(string givenString)
    {
        var count = new int[arraySize];
        for (var i = 0; i < givenString.Length; i++)
        {
            count[givenString[i]]++;
        }
        var sortArray = new char[givenString.Length];
        int position = 0;
        for (int i = 0; i < count.Length; i++)
        {
            for (int j = 0; j < count[i]; j++)
            {
                sortArray[position] = (char)i;
                position++;
            }
        }
        var sortString = new string(sortArray);
        return sortString;
    }

    private static string GetString(string givenString, int index, int[] numbers)
    {
        var result = "";
        for (int i = 0; i < givenString.Length; i++)
        {
            result += givenString[index];
            index = Array.IndexOf(numbers, index);
        }
        return result.Substring(1, result.Length - 1);
    }

    /// <summary>
    /// Обратное преобразование БВТ
    /// </summary>
    /// <param name="givenString">Строка, над которой нужно совершить обратное преобразование</param>
    /// <param name="index">Индекс конца исходной строки, полученный из прямого БВТ</param>
    /// <returns></returns>
    public static string ReverseBwt(string givenString, int index)
    {
        var sortedString = SortingString(givenString);
        var repeats = new int[arraySize];
        var numbers = new int[givenString.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = sortedString.IndexOf(givenString[i]) + repeats[(int)givenString[i]];
            ++repeats[(int)givenString[i]];
        }
        var answerString = GetString(givenString, index, numbers);
        return answerString;
    }

    private static bool TestCase()
    {
        var (bwtString, index) = StraightBwt("каркаркар");
        return "каркаркар" == ReverseBwt(bwtString, index);
    }

    /// <summary>
    /// Основная программа, вызывающая БВТ
    /// </summary>
    /// <param name="args">Аргументы командной строки</param>
    public static void Main(string[] args)
    {
        if (!TestCase())
        {
            Console.WriteLine("В работе BWT произошла ошибка(");
            return;
        }
        Console.WriteLine("Введите строку для применения BWT");

        var inputString = Console.ReadLine();
        if (inputString == null)
        {
            throw new ArgumentNullException("Введена пустая строка(");
        }

        var (BwtString, indexToInverseBwt) = StraightBwt(inputString);
        Console.WriteLine(BwtString);
        Console.WriteLine("Обратный BWT:");
        Console.WriteLine(ReverseBwt(BwtString, indexToInverseBwt));
    }
}
