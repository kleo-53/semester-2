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
        graph.vertexList.Sort(CompareEdgesByWeight);
        foreach (var i in graph.vertexList)
        {
            if (graph.edgesCounter == graph.numVertices - 1)
            {
                break;
            }
            graph.DeleteEdge(i);
            if (!graph.isConnect(i.Item1, i.Item2))
            {
                var add1 = new Tuple<int, int>(i.Item2, i.Item3); 
                add1 = new Tuple<int, int>(i.Item1, i.Item3);
                graph.fromTo[i.Item1].Add(add1);
                graph.fromTo[i.Item2].Add(add1);
                graph.edgesCounter++;
            }
        }
        using var outputStream = new StreamWriter(outPath);

        for (int i = 0; i < graph.numVertices; i++)
        {
            graph.fromTo[i].Sort();
            string line = "";
            if (graph.fromTo[i].LongCount() > 0)
            {
                line += $"{i}: ";
                for (int j = 0; j < graph.fromTo[i].LongCount(); ++j)
                {
                    line += $"{graph.fromTo[i][j].Item1} ({graph.fromTo[i][j].Item2}) ";
                }
            }
            if (!line.Equals(""))
            {
                outputStream.WriteLine(line);
            }
        }
    }
}
