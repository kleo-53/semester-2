namespace Routers;

using System;
using System.Collections.Generic;

/// <summary>
/// Интерфейс графа
/// </summary>
internal interface IGraph
{
    /// <summary>
    /// Количество вершин в графе
    /// </summary>
    public int NumVertexes { get; set; }

    /// <summary>
    /// Список ребер
    /// </summary>
    public List<Tuple<int, int, int> > EdgesList { get; set; }

    /// <summary>
    /// Количество ребер
    /// </summary>
    public int EdgesCounter { get; set; }

    /// <summary>
    /// Проверка связности вершин
    /// </summary>
    /// <param name="currentVertex">Первая вершина</param>
    /// <param name="neededVertex">Вторая вершина</param>
    /// <returns>Можно ли добраться от одной вершины до другой</returns>
    public bool AreConnected(int currentVertex, int neededVertex);

    /// <summary>
    /// Удаляе ребро из графа
    /// </summary>
    /// <param name="i">Ребро</param>
    public void DeleteEdge(Tuple<int, int, int> i);

    /// <summary>
    /// Ребро, которое нужно добавить
    /// </summary>
    /// <param name="i">Добавляет удаленное ребро в граф</param>
    public void AddAgain(Tuple<int, int, int> i);

    /// <summary>
    /// Печатает граф в файл
    /// </summary>
    /// <param name="outPath">Путь к файлу, куда нужно вывести граф</param>
    public void PrintGraph(string outPath);
}
