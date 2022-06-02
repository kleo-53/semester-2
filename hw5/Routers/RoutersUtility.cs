namespace Routers;

using System;

/// <summary>
/// Утилита
/// </summary>
public class RoutersUtility
{
    private static int CompareEdgesByWeight(Tuple<int, int, int> a, Tuple<int, int, int> b)
        => (a.Item3 < b.Item3) ? -1 : 1;

    /// <summary>
    /// Утилита
    /// </summary>
    /// <param name="inPath">Путь к исходному файлу</param>
    /// <param name="outPath">Путь к выходному файлу</param>
    /// <returns>Связен граф или не связен</returns>
    public static bool Utility(string inPath, string outPath)
    {
        IGraph graph = new Graph(inPath);
        graph.EdgesList.Sort(CompareEdgesByWeight);
        var resultEdges = 0;
        var maxEdges = graph.EdgesList.Count;
        foreach (var i in graph.EdgesList)
        {
            if (graph.EdgesCounter == graph.NumVertexes - 1)
            {
                break;
            }
            graph.DeleteEdge(i);
            if (!graph.AreConnected(i.Item1, i.Item2))
            {
                graph.AddAgain(i);
                resultEdges++;
            }
        }
        if (resultEdges == maxEdges)
        {
            return false;
        }
        graph.PrintGraph(outPath);
        return true;
    }
}
