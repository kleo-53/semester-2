namespace Lzw;

using System.IO;

/// <summary>
/// Класс сжатия и распаковки файла алгоритмом LZW
/// </summary>
public static class Lzw
{
    /// <summary>
    /// Прямое преобразование Lzw
    /// </summary>
    /// <param name="givenName">Происходит сжатие файла по данному пути</param>
    /// <returns>Коэффициент сжатия</returns>
    public static double StraightLzw(string givenName)
    {
        var zipName = givenName.Substring(0, givenName.LastIndexOf('.')) + ".zipped";
        using (var fileStream = new FileStream(zipName, FileMode.Create, FileAccess.Write))
        {
            using (var printer = new StreamWriter(fileStream))
            {


                var extension = givenName.Substring(givenName.LastIndexOf('.'));
                printer.WriteLine(extension);

                var codeTable = new Dictionary<string, char>();
                for (int i = 0; i < 256; i++)
                {
                    codeTable[((char)i).ToString()] = (char)i;
                }
                var line = "";
                byte[] inputData = File.ReadAllBytes(givenName);
                var addedKeys = 0;
                var writtenSymbols = 0;
                for (int i = 0; i < inputData.Length; i++)
                {
                    var currentSymbol = (char)inputData[i];
                    if (codeTable.ContainsKey(line + currentSymbol))
                    {
                        line += currentSymbol;
                    }
                    else
                    {
                        writtenSymbols++;
                        printer.Write(codeTable[line]);
                        addedKeys++;
                        codeTable[line + currentSymbol] = (char)(255 + addedKeys);
                        line = currentSymbol.ToString();
                    }
                }
                writtenSymbols++;
                printer.Write(codeTable[line]);
                return writtenSymbols != 0 ? (double)inputData.Length / writtenSymbols : 0;
            }
        }
    }

    /// <summary>
    /// Распаковка файла алгоритмом Lzw
    /// </summary>
    /// <param name="fileName">Путь к файлу</param>
    /// <returns>Коэффициент расжатия</returns>
    public static double ReverseLzw(string fileName)
    {
        var data = File.ReadAllLines(fileName);
        var extension = data[0];
        var unzipName = fileName.Substring(0, fileName.LastIndexOf(".")) + extension;

        var linesToLzw = "";
        for (int i = 1; i < data.Length; i++)
        {
            linesToLzw += data[i];
            if (i != data.Length - 1)
            {
                linesToLzw += "\r\n";
            }
        }
        var codeTable = new Dictionary<char, string>();
        for (int i = 0; i < 256; i++)
        {
            codeTable[((char)i)] = ((char)i).ToString();
        }
        var writtenSymbols = 0;
        using (var fileStream = new FileStream(unzipName, FileMode.Create, FileAccess.Write))
        {
            using (var printer = new StreamWriter(fileStream))
            {
                string previousValue = "";
                var addedKeys = 0;
                for (int i = 0; i < linesToLzw.Length; i++)
                {
                    if (codeTable.ContainsKey(linesToLzw[i]))
                    {
                        var line = codeTable[linesToLzw[i]];
                        writtenSymbols += line.Length;
                        printer.Write(line);
                        if (previousValue != "")
                        {
                            addedKeys++;
                            codeTable[(char)(255 + addedKeys)] = previousValue + line.Substring(0, 1);
                        }
                        previousValue = line;
                    }
                    else
                    {
                        var createdValue = previousValue + previousValue.Substring(0, 1);
                        printer.Write(createdValue);
                        writtenSymbols += createdValue.Length;
                        addedKeys++;
                        codeTable[(char)(255 + addedKeys)] = createdValue;
                        previousValue = codeTable[linesToLzw[i]];
                    }
                }
                return linesToLzw.Length != 0 ? (double)writtenSymbols / linesToLzw.Length : 0;
            }
        }
    }

    public static void Main(string[] args)
    {
        try
        {
            var filePath = args[1];
            var fileAction = args[0];
            var coefficient = 1.0;
            if (fileAction == "-c")
            {
                coefficient = StraightLzw(filePath);
            }
            else if (fileAction == "-u")
            {
                coefficient = ReverseLzw(filePath);
            }
            else
            {
                throw new ArgumentException("Введено некорректное действие");
            }
            Console.WriteLine($"Коэффициент сжатия текста равен: {coefficient}");
        }
        catch (IndexOutOfRangeException)
        {
            throw new IndexOutOfRangeException("Введена пустая строка!"); 
        }
    }
}