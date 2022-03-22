using System.IO;

namespace Lzw;

public class Lzw
{
    public static double StraightLzw(string givenName)
    {
        string zipName = givenName.Substring(0, givenName.LastIndexOf('.')) + ".zipped";
        FileStream fileStream = new FileStream(zipName, FileMode.Create, FileAccess.Write);
        StreamWriter printer = new StreamWriter(fileStream);

        string extension = givenName.Substring(givenName.LastIndexOf('.'));
        printer.WriteLine(extension);

        var codeTable = new Dictionary<string, char>();
        for (int i = 0; i < 256; i++)
        {
            codeTable[((char)i).ToString()] = (char)i;
        }
        string line = "";
        byte[] inputData = File.ReadAllBytes(givenName);
        int addedKeys = 0;
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
        printer.Close();
        fileStream.Close();
        try
        {
            return (double)inputData.Length / writtenSymbols;
        }
        catch (ArgumentNullException)
        {
            return 1;
        }
    }

    public static double ReverseLzw(string fileName)
    {
        string[] data = File.ReadAllLines(fileName);
        string extension = data[0];
        string unzipName = fileName.Substring(0, fileName.LastIndexOf(".")) + extension;

        string linesToLzw = "";
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
        FileStream fileStream = new FileStream(unzipName, FileMode.Create, FileAccess.Write);
        StreamWriter printer = new StreamWriter(fileStream);
        string previousValue = "";
        int addedKeys = 0;
        var writtenSymbols = 0;
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
        printer.Close();
        fileStream.Close();
        try
        {
            return (double)writtenSymbols / linesToLzw.Length;
        }
        catch (ArgumentNullException)
        {
            return 1;
        }
    }

    public static void Main(string[] args)
    {
        var inputLine = "";
        Console.WriteLine("Введите путь к файлу и то, что с ним нужно сделать:\n");
        inputLine = Console.ReadLine();
        try
        {
            var inputs = inputLine.Split(" ");
            var filePath = inputs[0];
            var fileAction = inputs[1];
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
        //StraightLzw("C:/Users/Star/source/repos/semester-2/hw3/Lzw/TestText.txt");
        //ReverseLzw("C:/Users/Star/source/repos/semester-2/hw3/Lzw/TestText.zipped");
        //save, empty str, no exist file,
    }
}