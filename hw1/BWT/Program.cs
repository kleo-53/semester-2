using System;

public class Bwt
{
    private static void Swap(ref string first, ref string second)
    {
        var temporary = first;
        first = second;
        second = temporary;
    }
    private static void SuffixesSort(ref string[] suffixes)
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

    public static (string, int) StraightBwt(string givenString)
    {
        var indexToInverseBwt = -1;
        givenString += '\0';
        var suffixes = new string[givenString.Length];
        for (int i = 0; i < givenString.Length; i++)
        {
            suffixes[i] = givenString.Substring(i);
        }
        SuffixesSort(ref suffixes);
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
    public static int arraySize = 10000;
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
    private static string GetString(string givenString, int[] numbers)
    {
        int index = givenString.IndexOf('\0');
        var result = "";
        for (int i = 0; i < givenString.Length; i++)
        {
            result += givenString[index];
            index = Array.IndexOf(numbers, index);
        }
        return result.Substring(1, result.Length - 1);
    }
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
        var answerString = GetString(givenString, numbers);
        return answerString;
    }
    private static bool testCase()
    {
        var (bwtString, index) = StraightBwt("каркаркар");
        return "каркаркар" == ReverseBwt(bwtString, index);
    }
    static void Main(string[] args)
    {
        if (!testCase())
        {
            Console.WriteLine("В работе BWT произошла ошибка(");
            return;
        }
        Console.WriteLine("Введите строку для применения BWT");
        var inputString = Console.ReadLine();
        var (BwtString, indexToInverseBwt) = StraightBwt(inputString);
        Console.WriteLine(BwtString);
        Console.WriteLine("Обратный BWT:");
        Console.WriteLine(ReverseBwt(BwtString, indexToInverseBwt));
    }
}
