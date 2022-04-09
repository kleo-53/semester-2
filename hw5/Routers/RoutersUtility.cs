using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routers;

public static class RoutersUtility
{
    private static int CompareEdgesByWeight(Tuple<int, int, int> a, Tuple<int, int, int> b)
    {
        return (a.Item3 < b.Item3) ? -1 : 1;
    }

    public static void Utility(string inPath, string outPath)
    {
        IGraph graph = new Graph(inPath);
        graph.VertexList.Sort(CompareEdgesByWeight);
        foreach (var i in graph.VertexList)
        {
            if (graph.EdgesCounter == graph.NumVertexes - 1)
            {
                break;
            }
            graph.DeleteEdge(i);
            if (!graph.IsConnect(i.Item1, i.Item2))
            {
                graph.AddAgain(i);
            }
        }

        graph.PrintGraph(outPath);
    }
}
