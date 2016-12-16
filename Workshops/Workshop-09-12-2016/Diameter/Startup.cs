using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diameter
{
    class Startup
    {
        // This is not a valid solution for now!!!

        static int n = int.Parse(Console.ReadLine());
        static Graph graph = new Graph(n);
        static bool[] visited = new bool[n];
        static int longest = 0;
        static int root;

        static void Main()
        {
            for (int i = 0; i < n - 1; i++)
            {
                var line = Console.ReadLine().Split(' ');
                var firstNode = int.Parse(line[0]);
                var secondNode = int.Parse(line[1]);
                var length = int.Parse(line[2]);
                if(graph.GetSuccessors(firstNode).Count == 0 && graph.GetSuccessors(secondNode).Count == 0)
                {
                    root = firstNode;
                }
                graph.AddEdge(firstNode, secondNode, length);
                graph.AddEdge(secondNode, firstNode, length);
            }

            longest = TraverseDFS(root);
            Console.WriteLine(longest);
        }

        static int TraverseDFS(int v)
        {
            var currentBest = 0;
            List<int> results = new List<int>();
            if (!visited[v])
            {
                visited[v] = true;
                var successor = graph.GetSuccessors(v);
                for (int i = 0; i < successor.Count; i += 2)
                {
                    var next = successor[i];
                    if (!visited[next])
                    {
                        results.Add(TraverseDFS(next) + successor[i + 1]);
                    }
                }
                if (results.Count > 0)
                {
                    currentBest = results.Max();
                }
            }

            return currentBest;
        }
    }
    public class Graph
    {
        // Contains the child nodes for each vertex of the graph
        // assuming that the vertices are numbered 0 ... Size-1
        private List<int>[] childNodes;

        /// <summary>Constructs an empty graph of given size</summary>
        /// <param name="size">number of vertices</param>
        public Graph(int size)
        {
            this.childNodes = new List<int>[size];
            for (int i = 0; i < size; i++)
            {
                // Assing an empty list of adjacents for each vertex
                this.childNodes[i] = new List<int>();
            }
        }

        /// <summary>Constructs a graph by given list of
        /// child nodes (successors) for each vertex</summary>
        /// <param name="childNodes">children for each node</param>
        public Graph(List<int>[] childNodes)
        {
            this.childNodes = childNodes;
        }

        /// <summary>
        /// Returns the size of the graph (number of vertices)
        /// </summary>
        public int Size
        {
            get { return this.childNodes.Length; }
        }

        /// <summary>Adds new edge from u to v</summary>
        /// <param name="u">the starting vertex</param>
        /// <param name="v">the ending vertex</param>
        /// <param name="length">the length of the edge</param>
        public void AddEdge(int u, int v, int length)
        {
            childNodes[u].Add(v);
            childNodes[u].Add(length);
        }

        /// <summary>Returns the successors of a given vertex
        /// </summary>
        /// <param name="v">the vertex</param>
        /// <returns>list of all successors of vertex v</returns>
        public IList<int> GetSuccessors(int v)
        {
            return childNodes[v];
        }

        //public string PrintGraph()
        //{
        //    var result = new StringBuilder();
        //    for (int i = 0; i < this.childNodes.Length; i++)
        //    {
        //        var node = this.childNodes[i];
        //        result.AppendLine($"Node: {i} -> {string.Join(", ", node)}");
        //    }

        //    return result.ToString();
        //}
    }
}
