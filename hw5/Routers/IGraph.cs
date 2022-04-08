using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routers
{
    internal interface IGraph
    {
        public int numVertices { get; set; }
        public List<Tuple<int, int, int> > vertexList { get; set; }
        public List<Tuple<int, int> >[] fromTo { get; set; }
        public int edgesCounter { get; set; }
        public bool isConnect(int currentVertex, int neededVertex);
        public void DeleteEdge(Tuple<int, int, int> i);
    }
}
