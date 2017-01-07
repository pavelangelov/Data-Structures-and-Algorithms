using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconstruction
{
    public class Program
    {
        public static int buildCost = 0;
        public static int destroyCost = 0;
        public static string alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static List<char>[] build;
        private static List<char>[] destroy;

        public static void Main()
        {

            var n = int.Parse(Console.ReadLine());

            var paths = new Graph(n);
            GetPaths(paths, n);
            build = GetValues(n);
            destroy = GetValues(n);
            for (int i = 0; i < n; i++)
            {
                if (paths.GetSuccessors(i).Count == 0)
                {
                    BuildPath(paths, i);
                }
                else
                {
                    bool[] visited = new bool[n];
                    var loopFound = DFS(paths, visited, i, -1);
                    if (loopFound && paths.GetSuccessors(i).Count > 1)
                    {
                        DestroyPath(paths, i);
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                var visited = new bool[n];
                DFS(paths, visited, i, -1);
                var nodeToConnect = new List<int>();
                for (int j = 0; j < visited.Length; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }

                    if (!visited[j])
                    {
                        nodeToConnect.Add(j);
                    }
                }

                if (nodeToConnect.Count > 0)
                {
                    BuildPath(paths, i, nodeToConnect);
                }
            }

            Console.WriteLine(buildCost + destroyCost);
            //Console.WriteLine(paths.PrintGraph());
        }

        static bool DFS(Graph graph, bool[] visited, int currentNode, int startNode)
        {
            if (currentNode == startNode || visited[currentNode])
            {
                return true;
            }
            else if (!visited[currentNode])
            {
                visited[currentNode] = true;
                foreach (var edge in graph.GetSuccessors(currentNode))
                {
                    if (edge == startNode)
                    {
                        continue;
                    }
                    var hasLoop = DFS(graph, visited, edge, currentNode);
                    if (hasLoop)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void DestroyPath(Graph paths, int i)
        {
            var currentNode = paths.GetSuccessors(i);
            var worstPath = int.MaxValue;
            var neighbour = -1;
            for (int j = 0; j < currentNode.Count; j++)
            {
                var next = currentNode[j];
                var pathValue = alfabet.IndexOf(destroy[i][next]);
                if (worstPath > pathValue)
                {
                    worstPath = pathValue;
                    neighbour = next;
                }
            }

            if (neighbour >= 0)
            {
                paths.RemoveEdge(i, neighbour);
                destroyCost += worstPath;
            }
        }

        private static void BuildPath(Graph paths, int i, List<int> nodeToConnect = null)
        {
            var bestPath = int.MaxValue;
            var neighbour = -1;
            if (nodeToConnect != null)
            {
                for (int j = 0; j < nodeToConnect.Count; j++)
                {
                    var node = nodeToConnect[j];
                    var pathValue = alfabet.IndexOf(build[i][node]);
                    if (bestPath > pathValue)
                    {
                        bestPath = pathValue;
                        neighbour = node;
                    }
                }
            }
            else
            {
                for (int j = 0; j < build.Length; j++)
                {
                    if (j == i || paths.GetSuccessors(i).Contains(j))
                    {
                        continue;
                    }
                    var pathValue = alfabet.IndexOf(build[i][j]);
                    if (bestPath > pathValue)
                    {
                        bestPath = pathValue;
                        neighbour = j;
                    }
                }
            }

            if (neighbour >= 0)
            {
                paths.AddEdge(i, neighbour);
                buildCost += bestPath;
            }
        }

        private static List<char>[] GetValues(int n)
        {
            var result = new List<char>[n];
            for (int i = 0; i < n; i++)
            {
                // This line is for BgCoder.
                var line = Console.ReadLine().ToCharArray().ToList();
                // var line = Console.ReadLine().Split(' ').Select(x => char.Parse(x)).ToList();
                result[i] = line;
            }

            return result;
        }

        private static void GetPaths(Graph paths, int n)
        {
            for (int i = 0; i < n; i++)
            {
                // var line = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

                // This line is for BgCoder.
                var line = Console.ReadLine().ToCharArray()
                                            .Select(x => x - '0')
                                            .ToList();
                for (int j = 0; j < line.Count; j++)
                {
                    if (line[j] == 1)
                    {
                        paths.AddEdge(i, j);
                    }
                }
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

            public List<int>[] ChildNodes
            {
                get { return this.childNodes; }
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
            public void AddEdge(int u, int v)
            {
                if (!childNodes[u].Contains(v))
                {
                    childNodes[u].Add(v);
                }

                if (!childNodes[v].Contains(u))
                {
                    childNodes[v].Add(u);
                }
            }

            public void CleanDirtyPaths(int u, int pathToStay)
            {
                childNodes[u].Clear();
                childNodes[u].Add(pathToStay);
            }

            public void RemoveEdge(int u, int v)
            {
                childNodes[u].Remove(v);
                childNodes[v].Remove(u);
            }

            public bool HasPath(int firstNode, int secondNode)
            {
                if (this.childNodes[firstNode].Count == 1)
                {
                    return false;
                }
                return this.childNodes[firstNode].Contains(secondNode);
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
}

//                              TESTS

/*
3
0 0 0
0 0 0
0 0 0
A B D
B A C
D C A
A B D
B A C
D C A

    result -> 3
==================================

3
0 1 1
1 0 1
1 1 0
A B D
B A C
D C A
A B D
B A C
D C A

    result -> 1
=================================
6
0 1 1 0 0 0
1 0 1 0 0 0
1 1 0 0 0 0
0 0 0 0 1 1
0 0 0 1 0 1
0 0 0 1 1 0
A B D F F F
B A C F F F
D C A F F F
F F F A B D
F F F B A C
F F F D C A
A B D F F F
B A C F F F
D C A F F F
F F F A B D
F F F B A C
F F F D C A

    result -> 7 ???
 */
