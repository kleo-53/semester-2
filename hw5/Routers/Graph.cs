using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routers;

public class Graph : IGraph
{
    public int numVertices { get; set; }
    public List<Tuple<int, int, int> > vertexList { get; set; }
    public List<Tuple<int, int> >[] fromTo { get; set; }
    public int edgesCounter {  get; set; }
    private bool[] visited;

    public Graph(string path) 
    {
        edgesCounter = 0;
        Parse(path);
    }

    void addEdge(int from, int to, int weight)
    {
        var add1 = new Tuple<int, int>(to, weight);
        add1 = new Tuple<int, int>(from, weight);
        fromTo[from].Add(add1);
        fromTo[to].Add(add1);
        edgesCounter++;
        var add = new Tuple<int, int, int>(from, to, weight);
        vertexList.Add(add);
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
            this.numVertices = Math.Max(numVertices, startNode);

            for (var i = 1; i < splitLine.Length; i++)
            {
                string[] splitSplitLine = splitLine[i].Split("(");

                int finishNode = int.Parse(splitSplitLine[0]);
                this.numVertices = Math.Max(numVertices, finishNode);
                int weight = int.Parse(splitSplitLine[1].Split(")")[0]);
                addEdge(startNode, finishNode, weight);
            }
        }
    }

    public bool isConnect(int currentVertex, int neededVertex)
    {
        //bool[] visited = new bool[numVertices];
        return DFS(currentVertex, neededVertex, ref visited);
    }

    private bool DFS(int currentVertex, int neededVertex, ref bool[] visited)
    {
        if (currentVertex == neededVertex)
        {
            return true;
        }
        visited[currentVertex] = true;
        List<Tuple<int, int> > adjList = fromTo[currentVertex];
        for (var i = adjList.First().Item1; i != adjList.Last().Item1; ++i)
        {
            if (!visited[i] && DFS(i, neededVertex, ref visited))
            {
                return true;
            }
        }
        return false;
    }
    public void DeleteEdge(Tuple<int, int, int> i)
    {
        var add1 = new Tuple<int, int>(i.Item2, i.Item3);
        fromTo[i.Item1].Remove(add1);
        add1 = new Tuple<int, int>(i.Item1, i.Item3);
        fromTo[i.Item2].Remove(add1);
        edgesCounter--;
    }
}
