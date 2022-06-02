namespace Routers;

using System;
using System.Collections.Generic;

/// <summary>
/// Класс графа, в котором хранятся данные
/// </summary>
public class Graph : IGraph
{
    /// <summary>
    /// Количество вершин в графе
    /// </summary>
    public int NumVertexes { get; set; }

    /// <summary>
    /// Список ребер
    /// </summary>
    public List<Tuple<int, int, int>> EdgesList { get; set; }

    /// <summary>
    /// Количество ребер
    /// </summary>
    public int EdgesCounter { get; set; }

    private int[,] fromTo;
    private bool[] visited;
    private int fromToSize;

    /// <summary>
    /// Конструктор графа
    /// </summary>
    /// <param name="path">Путь к файлу</param>
    public Graph(string path) 
    {
        EdgesList = new List<Tuple<int, int, int>>();
        fromToSize = 10;
        fromTo = new int[fromToSize, fromToSize];
        Parse(path);
    }

    private void Resize()
    {
        fromToSize *= 2;
        var newFromTo = new int[fromToSize, fromToSize];
        for (int i = 0; i < NumVertexes; ++i)
        {
            for (int j = 0; j < NumVertexes; ++j)
            {
                newFromTo[i, j] = fromTo[i, j];
            }
        }
        fromTo = newFromTo;
    }

    private void AddEdge(int from, int to, int weight)
    {
        while (from > fromToSize || to > fromToSize)
        {
            Resize();
        }
        fromTo[from, to] = weight;
        fromTo[to, from] = weight;
        EdgesCounter++;
        var add = new Tuple<int, int, int>(from, to, weight);
        EdgesList.Add(add);
    }

    /// <summary>
    /// Добавление ребра после удаления
    /// </summary>
    /// <param name="i">Массив из двух вершин и ребра</param>
    public void AddAgain(Tuple<int, int, int> i)
    {
        fromTo[i.Item1, i.Item2] = i.Item3;
        fromTo[i.Item2, i.Item1] = i.Item3;
        EdgesCounter++;
    }

    private void Parse(string path)
    {
        using StreamReader reader = new StreamReader(path);
        while (true)
        {
            string? line = reader.ReadLine();
            if (line == null)
            {
                return;
            }
            string[] splitLine = line.Split(" ");
            int startNode = int.Parse(splitLine[0].Split(":")[0]);
            this.NumVertexes = Math.Max(NumVertexes, startNode);

            for (var i = 1; i < splitLine.Length; i += 2)
            {
                string[] splitSplitLine = splitLine[i + 1].Split("(");

                int finishNode = int.Parse(splitLine[i]);
                this.NumVertexes = Math.Max(NumVertexes, finishNode);
                int weight = int.Parse(splitSplitLine[1].Split(")")[0]);
                AddEdge(startNode, finishNode, weight);
            }
        }
    }

    /// <summary>
    /// Проверка на связность двух вершин
    /// </summary>
    /// <param name="currentVertex">Первая вершина</param>
    /// <param name="neededVertex">Та вершина, до которой проверяем связность</param>
    /// <returns>Связаны или нет</returns>
    public bool AreConnected(int currentVertex, int neededVertex)
    {
        visited = new bool[NumVertexes + 1];
        return DFS(currentVertex, neededVertex, ref visited);
    }

    private bool DFS(int currentVertex, int neededVertex, ref bool[] visited)
    {
        if (currentVertex == neededVertex)
        {
            return true;
        }
        visited[currentVertex] = true;
        for (var i = 0; i <= NumVertexes; ++i)
        {
            if (fromTo[currentVertex, i] != 0 && !visited[i] && DFS(i, neededVertex, ref visited))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Удаление ребра
    /// </summary>
    /// <param name="i"></param>
    public void DeleteEdge(Tuple<int, int, int> i)
    {
        fromTo[i.Item1, i.Item2] = 0;
        fromTo[i.Item2, i.Item1] = 0;
        EdgesCounter--;
    }

    /// <summary>
    /// Даспечатывает раф в файл
    /// </summary>
    /// <param name="outPath">Путь к файлу</param>
    public void PrintGraph(string outPath)
    {
        using var outputStream = new StreamWriter(outPath);
        for (int i = 1; i <= NumVertexes; i++)
        {
            string line = "";
            bool notConnectYet = true;
            for (int j = i; j <= NumVertexes; j++)
            {
                if (fromTo[i, j] > 0)
                {
                    if (notConnectYet)
                    {
                        line += $"{i}: ";
                        notConnectYet = false;
                    }
                    line += $"{j} ({fromTo[i, j]}), ";
                }
            }
            if (!notConnectYet)
            {
                outputStream.WriteLine(line.Substring(0, line.Length - 2));
            }
        }
    }
}
