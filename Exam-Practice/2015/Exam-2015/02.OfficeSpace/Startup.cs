using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OfficeSpace
{
    class Startup
    {
        static int[] paths;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var graph = new List<Tuple<int, int>>[n + 1];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<Tuple<int, int>>();
            }

            var values = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                var value = int.Parse(values[i]);
                var siblings = Console.ReadLine().Split(' ');
                for (int j = 0; j < siblings.Length; j++)
                {
                    var node = int.Parse(siblings[j]);

                    graph[node].Add(new Tuple<int, int>(i + 1, value));
                }
            }
            if (graph[0].Count < 1)
            {
                Console.WriteLine(-1);
                return;
            }

            var len = int.MinValue;
            for (int i = 0; i <= n; i++)
            {
                bool[] visited = new bool[n + 1];
                paths = new int[n + 1];
                try
                {
                    var currentLen = DFS(graph, visited, i);

                    if (len < currentLen)
                    {
                        len = currentLen;
                    }
                }
                catch (ArgumentException)
                {
                    len = -1;
                    break; ;
                }
            }

            Console.WriteLine(len);
        }

        static int DFS(List<Tuple<int, int>>[] graph, bool[] visited, int currentNode)
        {
            if (visited[currentNode])
            {
                throw new ArgumentException();
            }

            if (!visited[currentNode])
            {
                if (paths[currentNode] > 0)
                {
                    return paths[currentNode];
                }

                visited[currentNode] = true;
                List<int> lengths = new List<int>();
                foreach (var node in graph[currentNode])
                {
                    lengths.Add(DFS(graph, visited, node.Item1) + node.Item2);
                }
                int max;
                if (lengths.Count > 0)
                {
                    max = lengths.Max();
                }
                else
                {
                    max = 0;
                }

                paths[currentNode] = max;
            }

            visited[currentNode] = false;

            return paths[currentNode];
        }
    }

}
