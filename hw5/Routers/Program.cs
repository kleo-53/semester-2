using Routers;

if (args.Length < 2)
{
    Console.WriteLine("Недостаточное количество аргументов (ведите два пути до файлов)");
}
string inPath = args[0];
string outPath = args[1];
if (!RoutersUtility.Utility(inPath, outPath))
{
    Console.Error.WriteLine("Граф не связный!");
}
